using System;
//using System.Data.SqlClient;
using System.Data.OleDb;
using System.Web.Configuration;
using System.Collections.Generic;
using PropertyPhoto.BusinessLogicLayer;

namespace PropertyPhoto.DataAccessLayer
{
    /// <summary>
    /// Data Access Layer for interacting with Microsoft
    /// SQL Server 2005
    /// </summary>
    public class SqlDataAccessLayerPhoto
    {
        private static readonly string _connectionString = string.Empty;

        /// <summary>
        /// Selects all photos from the database
        /// </summary>
        public List<Photo> PhotoSelectAll(int photoProjectID)
        {
            // Create Photo collection
            List<Photo> colPhotos = new List<Photo>();
            
            // Create connection
            OleDbConnection con = new OleDbConnection(_connectionString);

            // Create command
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT photoId, photoName, photoProjectID FROM images WHERE (photoProjectID = @photoProjectID)";
            
            // Add parameters
            cmd.Parameters.AddWithValue("@photoProjectID", photoProjectID);
            // Execute command
            using (con)
            {
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    colPhotos.Add(new Photo(
                        (int)reader["photoId"],
                        (string)reader["photoName"],
                        (int)reader["photoProjectID"]));
                }
            }
            return colPhotos;
        }


        /// <summary>
        /// Selects all photos from the database
        /// </summary>
        public List<Photo> PhotoSelectOne(int photoProjectID)
        {
            // Create Photo collection
            List<Photo> colPhotos = new List<Photo>();

            // Create connection
            OleDbConnection con = new OleDbConnection(_connectionString);

            // Create command
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT TOP 1 photoId, photoName, photoProjectID FROM images WHERE (photoProjectID = @photoProjectID)";

            // Add parameters
            cmd.Parameters.AddWithValue("@photoProjectID", photoProjectID);
            // Execute command
            using (con)
            {
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    colPhotos.Add(new Photo(
                        (int)reader["photoId"],
                        (string)reader["photoName"],
                        (int)reader["photoProjectID"]));
                }
            }
            return colPhotos;
        }

        /// <summary>
        /// Inserts a new photo into the database
        /// </summary>
        /// <param name="newphoto">Photo</param>


        public void PhotoInsert(Photo newPhoto)
        {
            // Create connection
            OleDbConnection con = new OleDbConnection(_connectionString);

            // Create command
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO images (photoName, photoProjectID) VALUES (@photoName, @photoProjectID)";
           

            // Add parameters
            cmd.Parameters.AddWithValue("@photoName", newPhoto.photoName);
            cmd.Parameters.AddWithValue("@photoProjectID", newPhoto.photoProjectID);

            // Execute command
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
        ///////////////////////////////////////////////
       

        /// <summary>
        /// Updates an existing photo into the database
        /// </summary>
        /// <param name="photoToUpdate">Photo</param>
        public void PhotoUpdate(Photo photoToUpdate)
        {
            // Create connection
            OleDbConnection con = new OleDbConnection(_connectionString);

            // Create command
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE images SET photoName=@photoName, photoProjectID =@photoProjectID WHERE photoId=@photoId";

            // Add parameters
           
            cmd.Parameters.AddWithValue("@photoName", photoToUpdate.photoName);
            cmd.Parameters.AddWithValue("@photoProjectID", photoToUpdate.photoProjectID);
            // Execute command
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        /// <summary>
        /// Deletes an existing photo in the database
        /// </summary>
        /// <param name="id">Photo photoId</param>
        public void PhotoDelete(int photoID)
        {
            // Create connection
            OleDbConnection con = new OleDbConnection(_connectionString);

            // Create command
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM [images] WHERE [photoID]=@photoID";

            // Add parameters
            cmd.Parameters.AddWithValue("@photoID", photoID);

            // Execute command
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        /// <summary>
        /// Initialize the data access layer by
        /// loading the database connection string from 
        /// the Web.Config file
        /// </summary>
        static SqlDataAccessLayerPhoto()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            if (string.IsNullOrEmpty(_connectionString))
                throw new Exception("No connection string configured in Web.Config file");
        }
    }
}