using PIM_VIII.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace PIM_VIII
{
    public class Helper
    {
        readonly TarefaDBContext _db = new TarefaDBContext();

        public int OverdueTotal()
        {
            var hoje = DateTime.Now.Date;

            return _db.Tarefas.Where(a => DbFunctions.TruncateTime(a.Vencimento) < hoje).Count();
        }
    }
}