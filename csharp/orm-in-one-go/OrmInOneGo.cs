using System;

public class Orm(Database database)
{
    public void Write(string data)
    {
        using var db = database;
        db.BeginTransaction();
        db.Write(data);
        db.EndTransaction();
    }

    public bool WriteSafely(string data)
    {
        try
        {
            Write(data);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
