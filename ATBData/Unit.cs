using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATB.Data
{
    [Serializable]
    public class Hero
    {
        //уровень
        public int Level;

        //навыки
        public int Attack;
        public int Defense;
        public int SpellPower;
        public int Knowledge;
        public int Luck;
        public int Morale;
        public decimal Initiative;

        //фракция
        public enum FractionKind
        {
            Knight,
            Necromancer,
            Wizard,
            Elf,
            Barbarian,
            DarkElf,
            Demon,
            Dwarf,
        }
        public FractionKind Fraction;

        //умелка
        public int Knight;
        public int Necromancer;
        public int Wizard;
        public int Elf;
        public int Barbarian;
        public int DarkElf;
        public int Demon;
        public int Dwarf;

        //перки
        //...
    }

    [Serializable]
    public class Unit : ICloneable
    {
        public int id;
        public string name;
        public int side;

        public decimal curATB;
        public decimal ini;

        public int ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Side { get { return side; } set { side = value; } }
        public decimal CurATB { get { return curATB; } set { curATB = value; } }
        public decimal Ini { get { return ini; } set { ini = value; } }

        public Unit()
        {
            id = 0;
            name = "";
            side = 1;
            curATB = 0;
            ini = 10;
        }

        public Unit(int id, string name, int side, decimal ini)
        {
            this.id = id;
            this.name = name;
            this.side = side;

            this.curATB = 0;
            this.ini = ini;

            //...
        }

        public Unit(Unit original)
        {
            this.id = original.id;
            this.name = original.name;
            this.side = original.side;

            this.curATB = original.curATB;
            this.ini = original.ini;

            //...
        }

        //мораль
        //удача
        //мораль (сколько раз сработало/не сработало)
        //удача (сколько раз сработало/не сработало)

        //кол-во
        //хп
        //атака
        //зашита
        //урон
        //скорость
        //координаты

        //мана
        //выстрелы
        //спецспособности

        #region [ ICloneable ]

        public object Clone()
        {
            return new Unit(this);
        }

        #endregion
    }

    //отряд + информация о его ходе
    [Serializable]
    public class UnitMove : ICloneable
    {
        public Unit unit;    //отряд, который отображаем в списке
        public bool old;     //это прогнозируемый ход или уже свершившийся?
        public decimal dist;    //расстояние до следующего отряда, который ходит после данного
        public decimal shift;   //смещение отряда по ATB в момент хода (по умолчанию - 100)
        public string comment; //комментарий к ходу

        public UnitMove(Unit unit)
        {
            this.unit = (Unit)unit.Clone();
            this.old = false;
            this.dist = 0;
            this.shift = 100;
            this.comment = "полный ход";
        }

        public UnitMove(Unit unit, bool old, decimal dist, decimal shift, string comment)
        {
            this.unit = (Unit)unit.Clone();
            this.old = old;
            this.dist = dist;
            this.shift = shift;
            this.comment = comment;
        }

        public UnitMove(UnitMove original)
        {
            this.unit = (Unit)original.unit.Clone();
            this.old = original.old;
            this.dist = original.dist;
            this.shift = original.shift;
            this.comment = original.comment;
        }

        public override string ToString()
        {
            return unit.id + " (" + dist + "): " + unit.name + " [ " + comment + " - " + shift + " ]";
        }

        #region [ ICloneable ]

        public object Clone()
        {
            return new UnitMove(this);
        }

        #endregion

    }

    //состояние стеков
    [Serializable]
    public class State : ICloneable
    {
        public List<Unit> Units = new List<Unit>();
        public List<UnitMove> OldMoves = new List<UnitMove>();

        public void Top()
        {
            int first;
            while ((first = FirstIndex()) == -1)
                Tick();
        }

        //выполнить ход самым первым стеком в очереди
        public void Move(int sub, string comment)
        {
            if (Units.Count <= 0)
                return;

            int first;
            while ((first = FirstIndex()) == -1)
                Tick();

            if (first != -1)
            {
                //запомнить ход
                OldMoves.Add(new UnitMove(Units[first], true, NextUnitDist(first), sub, comment));

                //переместить
                Units[first].curATB -= sub;
            }

            while ((first = FirstIndex()) == -1)
                Tick();
        }

        //получить линейку очередности ходов стеков
        public List<UnitMove> GetLine(int size)
        {
            List<UnitMove> list = new List<UnitMove>(OldMoves);

            if (Units.Count <= 0)
                return list;

            State tmp = (State)this.Clone();

            for (int i = 0; i < size; i++)
            {
                int first;
                while ((first = tmp.FirstIndex()) == -1)
                    tmp.Tick();

                UnitMove um = new UnitMove(tmp.Units[first]);
                um.dist = tmp.NextUnitDist(first);
                list.Add(um);

                tmp.Move(100, "");
            }

            return list;
        }

        //переместить все отряды на одну секунду
        public void Tick()
        {
            for (int i = 0; i < Units.Count; i++)
            {
                Unit unit = Units[i];
                unit.curATB += unit.ini;
                Units[i] = unit;
            }
        }

        //получить индекс отряда, который должен ходить первым
        public int FirstIndex()
        {
            int indx = -1;
            decimal max = 0;

            for (int i = 0; i < Units.Count; i++)
                //todo: проверить приоритет у тех, у кого одинаковая curATB (пока первый тот, кто выше в списке)
                if (Units[i].curATB > max && Units[i].curATB >= 100)
                {
                    max = Units[i].curATB;
                    indx = i;
                }

            return indx;
        }

        //расстояние до следующего юнита по шкале иннициативы
        decimal NextUnitDist(int indx)
        {
            if (indx < 0 || indx >= Units.Count)
                return -1;

            decimal dist = 100;

            for (int i = 0; i < Units.Count; i++)
                if (i != indx && Units[indx].curATB >= Units[i].curATB)
                    if (Units[indx].curATB - Units[i].curATB < dist)
                        dist = Units[indx].curATB - Units[i].curATB;

            return dist; //может врать, если юнит последний в линейке ATB, а усложнять пока - лень
        }

        #region [ ICloneable ]

        public object Clone()
        {
            State clone = new State();
            clone.Units = new List<Unit>(this.Units);
            clone.OldMoves = new List<UnitMove>(this.OldMoves);
            return clone;
        }

        #endregion

    }

    //управление ходами (ходы, полуходы, отмена и т.п.)
    [Serializable]
    public class StateManager
    {
        public Hero Hero = new Hero();

        #region [ управление текущим состоянием ]

        //список состояний (для возможности отмены)
        List<State> states = new List<State>();
        int stateindx = 0;

        //текущее состояние стеков
        public State CurrentState
        {
            get
            {
                if
                (
                    states.Count <= 0 ||
                    stateindx < 0 ||
                    stateindx >= states.Count
                )
                    return new State();

                State state = new State();

                foreach (Unit unit in states[stateindx].Units)
                    state.Units.Add((Unit)unit.Clone());

                foreach (UnitMove um in states[stateindx].OldMoves)
                    state.OldMoves.Add((UnitMove)um.Clone());

                return state;
            }
            set
            {
                if (stateindx < 0)
                    stateindx = 0;

                while (stateindx < states.Count - 1)
                    states.RemoveAt(states.Count - 1);

                states.Add(value);
                stateindx = states.Count - 1;
            }
        }

        //можно ли отменить предыдущий ход
        public bool CanUndo
        {
            get
            {
                return stateindx > 0;
            }
        }

        //можно ли "отменить" отмену
        public bool CanRedo
        {
            get
            {
                return stateindx < states.Count - 1;
            }
        }

        //отменить ход
        public void Undo()
        {
            stateindx = stateindx > 0 ? stateindx - 1 : 0;
        }

        //"отменить" отмену хода
        public void Redo()
        {
            stateindx = stateindx + 1 < states.Count ? stateindx + 1 : stateindx;
        }

        #endregion

        #region [ управление ходами ]

        //прогнать по шкале до хода первого юнита
        public void Top()
        {
            State state = CurrentState;

            state.Top();

            CurrentState = state;
        }

        //выполнить полный ход
        public void Move(string comment)
        {
            Move(100, comment);
        }

        //выполнить полуход
        public void Wait(string comment)
        {
            Move(50, comment);
        }

        //добавить стек к набору отрядов
        public void Add(Unit unit)
        {
            State state = CurrentState;

            state.Units.Add((Unit)unit.Clone());

            CurrentState = state;
        }

        //добавить стек к набору отрядов
        public void AddAfterFirst(Unit unit, int delta)
        {
            State state = CurrentState;
            unit = (Unit)unit.Clone();

            if (state.Units.Count > 0)
            {
                state.Top();

                Unit first = state.Units[state.FirstIndex()];
                unit.curATB = first.curATB - delta;
            }

            state.Units.Add(unit);

            CurrentState = state;
        }

        //удалить стек из набора отрядов
        public void Remove(int id)
        {
            State state = CurrentState;

            for (int i = state.Units.Count - 1; i >= 0; i--)
                if (state.Units[i].id == id)
                    state.Units.RemoveAt(i);

            CurrentState = state;
        }

        #endregion

        void Move(int sub, string comment)
        {
            State state = CurrentState;

            state.Move(sub, comment);

            CurrentState = state;
        }
    }
}
