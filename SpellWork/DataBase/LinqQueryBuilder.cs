using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions; // use class it's namespase
using System.Text;

namespace SpellWork
{
    class LinqQueryBuilder
    {
        // todo: implement qiery builder in parametr
        // return query result

        public void TestDynamicLinqQuery()
        {
            var custs = DBC.Spell.AsQueryable();
            
            ParameterExpression param = Expression.Parameter(typeof(SpellEntry), "spell");
            Expression right = Expression.Constant("ID");
            Expression left = Expression.Property(param, typeof(SpellEntry).GetProperty("SpellName"));
            Expression filter = Expression.Equal(left, right);
            Expression pred = Expression.Lambda(filter, param);

            Expression expr = Expression.Call(
                typeof(Queryable), 
                "Where", 
                new Type[] { typeof(SpellEntry) }, 
                Expression.Constant(custs), 
                pred);
            IQueryable<SpellEntry> query = DBC.Spell.AsQueryable().Provider.CreateQuery<SpellEntry>(expr);
        }
    }
}
