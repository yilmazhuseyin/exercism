using System;

public class Orm : IDisposable
{
    private Database _database;

    public Orm(Database database)
    {
        try
        {
            _database = database;
        }
        catch
        {
            _database.Dispose();
        }
    }

    public void Begin() => _database.BeginTransaction();

    public void Write(string data)
    {
        try
        {
            _database.Write(data);
        }
        catch
        {
            _database.Dispose();
        }
    }

    public void Commit()
    {
        try 
        {
            _database.EndTransaction();
        }
        catch
        {
            _database.Dispose();
        }
    }

    public void Dispose() => _database.Dispose();
}
