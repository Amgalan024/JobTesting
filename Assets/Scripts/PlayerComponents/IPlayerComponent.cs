using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface IPlayerComponent
{
    Player Player { set; get; }
    void InitializePlayer(Player player);
}
