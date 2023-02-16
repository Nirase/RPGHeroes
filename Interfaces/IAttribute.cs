using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Interfaces
{
    public interface IAttribute
    {
        int Strength { get; protected set; }
        int Dexterity { get; protected set; }
        int Intelligence { get; protected set; }
        public string ToString();
    }
}
