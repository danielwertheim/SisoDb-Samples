using SisoDb;
using SisoDb.Sql2012;

namespace Examples
{
    public abstract class Example
    {
        protected ISisoDatabase Db { get; private set; }

        protected Example()
        {
            Db = "Samples".CreateSql2012Db();
            Db.EnsureNewDatabase();
        }

        public abstract void Run();
    }
}