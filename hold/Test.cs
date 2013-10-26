using System;
using System.Collections.Generic;
using System.Web;
using System.Dynamics;
using WebMatrix.Data;
using System.Data.OleDb;
using System.Web.Configuration;

/// <summary>
/// Summary description for Test
/// </summary>
public class Test
{
    public static IEnumerable<dynamic> TestSQL(string conDatabase, string sqlquery)
    {
        //
        // TODO: Add constructor logic here
        //
        var db = Database.Open(conDatabase);
      var result = db.Query(sqlquery);
      return result;
    }
    
    
    public static dynamic testsingleSQL(string conDatabase, string sqlquery)
    {
      var db = Database.Open(conDatabase);
      var result = db.QuerySingle(sqlquery);
      return result;
    }
    

}

