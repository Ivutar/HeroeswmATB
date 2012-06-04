using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATB.Data;

namespace ATB.Win
{
    public partial class frmHero : Form
    {
        StateManager mgr;

        public frmHero()
        {
            InitializeComponent();
        }

        public void Show(StateManager mgr)
        {
            if (mgr != null)
            {
                this.mgr = mgr;

                udLevel.Value = mgr.Hero.Level;
                udAttack.Value = mgr.Hero.Attack;
                udDefense.Value = mgr.Hero.Defense;
                udSpellPower.Value = mgr.Hero.SpellPower;
                udKnowledge.Value = mgr.Hero.Knowledge;
                udLuck.Value = mgr.Hero.Luck;
                udMorale.Value = mgr.Hero.Morale;
                udInitiative.Value = mgr.Hero.Initiative;
                udKnight.Value = mgr.Hero.Knight;
                udNecromancer.Value = mgr.Hero.Necromancer;
                udWizard.Value = mgr.Hero.Wizard;
                udElf.Value = mgr.Hero.Elf;
                udBarbarian.Value = mgr.Hero.Barbarian;
                udDarkElf.Value = mgr.Hero.DarkElf;
                udDemon.Value = mgr.Hero.Demon;
                udDwarf.Value = mgr.Hero.Dwarf;

                switch (mgr.Hero.Fraction)
                {
                    case Hero.FractionKind.Knight: rbKnight.Checked = true; break;
                    case Hero.FractionKind.Necromancer: rbNecromancer.Checked = true; break;
                    case Hero.FractionKind.Wizard: rbWizard.Checked = true; break;
                    case Hero.FractionKind.Elf: rbElf.Checked = true; break;
                    case Hero.FractionKind.Barbarian: rbBarbarian.Checked = true; break;
                    case Hero.FractionKind.DarkElf: rbDarkElf.Checked = true; break;
                    case Hero.FractionKind.Demon: rbDemon.Checked = true; break;
                    case Hero.FractionKind.Dwarf: rbDwarf.Checked = true; break;
                }

                base.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mgr != null)
            {
                mgr.Hero.Level = (int)udLevel.Value;
                mgr.Hero.Attack = (int)udAttack.Value;
                mgr.Hero.Defense = (int)udDefense.Value;
                mgr.Hero.SpellPower = (int)udSpellPower.Value;
                mgr.Hero.Knowledge = (int)udKnowledge.Value;
                mgr.Hero.Luck = (int)udLuck.Value;
                mgr.Hero.Morale = (int)udMorale.Value;
                mgr.Hero.Initiative = (int)udInitiative.Value;
                mgr.Hero.Knight = (int)udKnight.Value;
                mgr.Hero.Necromancer = (int)udNecromancer.Value;
                mgr.Hero.Wizard = (int)udWizard.Value;
                mgr.Hero.Elf = (int)udElf.Value;
                mgr.Hero.Barbarian = (int)udBarbarian.Value;
                mgr.Hero.DarkElf = (int)udDarkElf.Value;
                mgr.Hero.Demon = (int)udDemon.Value;
                mgr.Hero.Dwarf = (int)udDwarf.Value;

                if (rbKnight.Checked) mgr.Hero.Fraction = Hero.FractionKind.Knight;
                if (rbNecromancer.Checked) mgr.Hero.Fraction = Hero.FractionKind.Necromancer;
                if (rbWizard.Checked) mgr.Hero.Fraction = Hero.FractionKind.Wizard;
                if (rbElf.Checked) mgr.Hero.Fraction = Hero.FractionKind.Elf;
                if (rbBarbarian.Checked) mgr.Hero.Fraction = Hero.FractionKind.Barbarian;
                if (rbDarkElf.Checked) mgr.Hero.Fraction = Hero.FractionKind.DarkElf;
                if (rbDemon.Checked) mgr.Hero.Fraction = Hero.FractionKind.Demon;
                if (rbDwarf.Checked) mgr.Hero.Fraction = Hero.FractionKind.Dwarf;

                Close();
            }
        }
    }
}
