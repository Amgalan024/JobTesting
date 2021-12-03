using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


interface IEnemyComponent
{
    Enemy Enemy { set; get; }
    void InitializeEnemy(Enemy enemy);
}
