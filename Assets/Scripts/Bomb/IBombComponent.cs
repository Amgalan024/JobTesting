using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface IBombComponent
{
    Bomb Bomb { set; get; }
    void InitializeBomb(Bomb bomb);
}
