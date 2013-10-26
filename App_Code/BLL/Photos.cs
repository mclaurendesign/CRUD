using System;
using System.Collections.Generic;
using PropertyPhoto.DataAccessLayer;

namespace PropertyPhoto.BusinessLogicLayer
{
    /// <summary>
    /// Represents a photo and all the methods
    /// for selecting, inserting, and updating a photo
    /// </summary>
    public class Photo
    {
        private int _photoID = 0;
        private string _photoName = String.Empty;
        private int _photoProjectID = 0;

        /// <summary>
        /// Photo Unique Identifier
        /// </summary>
        public int photoID
        {
            get { return _photoID; }
        }

        /// <summary>
        /// Photo Name
        /// </summary>
        public string photoName
        {
            get { return _photoName; }
        }

        /// <summary>
        /// Photo Property ID
        /// </summary>
        public int photoProjectID
        {
            get { return _photoProjectID; }
        }

        /// <summary>
        /// Retrieves all rentals
        /// </summary>
        /// <returns></returns>
        public static List<Photo> SelectOne(int projectID)
        {
            SqlDataAccessLayerPhoto dataAccessLayer = new SqlDataAccessLayerPhoto();
            return dataAccessLayer.PhotoSelectOne(projectID);
        }


        /// <summary>
        /// Retrieves all rentals
        /// </summary>
        /// <returns></returns>
        public static List<Photo> SelectAll(int projectID)
        {
            SqlDataAccessLayerPhoto dataAccessLayer = new SqlDataAccessLayerPhoto();
            return dataAccessLayer.PhotoSelectAll(projectID);
        }


        /// <summary>
        /// Updates a particular photo
        /// </summary>
        /// <param name="photoId">Photo Id</param>
        /// <param name="photoName">Photo Name</param>
        /// <param name="propertyId">Photo Property ID</param>
        public static void Update(int id, string photoName, int photoProjectID)
        {
            if (id < 1)
                throw new ArgumentException("Photo Id must be greater than 0", "id");

            Photo photoToUpdate = new Photo(id, photoName, photoProjectID);
            photoToUpdate.Save();
        }

        /// <summary>
        /// Inserts a new photo
        /// </summary>
        /// <param name="photoName">Photo Name</param>
        /// <param name="photoProjectID">Photo Property ID</param>
        public static void Insert(string photoName, int photoProjectID)
        {
            Photo newPhoto = new Photo(photoName, photoProjectID);
            newPhoto.Save();
        }

        /// <summary>
        /// Deletes an existing photo
        /// </summary>
        /// <param name="id">Photo Id</param>
        public static void Delete(int original_photoID)
        {
            if (original_photoID < 1)
                throw new ArgumentException("Photo Id must be greater than 0", "id");

            SqlDataAccessLayerPhoto dataAccessLayer = new SqlDataAccessLayerPhoto();
            dataAccessLayer.PhotoDelete(original_photoID);
        }

        /// <summary>
        /// Validates photo information before saving photo
        /// properties to the database
        /// </summary>
        private void Save()
        {
            if (String.IsNullOrEmpty(_photoName))
                throw new ArgumentException("Photo name not supplied", "photoName");
            //if (String.IsNullOrEmpty(_propertyId))
            // throw new ArgumentException("Photo property ID not supplied", "propertyId");
            // ADD EXCEPTION FOR PHOTOID NOT NUMERIC

            SqlDataAccessLayerPhoto dataAccessLayer = new SqlDataAccessLayerPhoto();
            if (_photoID > 0)
                dataAccessLayer.PhotoUpdate(this);
            else
                dataAccessLayer.PhotoInsert(this);
        }

        /// <summary>
        /// Initializes Photo
        /// </summary>
        /// <param name="photoName">Photo Name</param>
        /// <param name="photoProjectID">Photo Property ID</param>
        public Photo(string photoName, int photoProjectID)
            : this(0, photoName, photoProjectID) { }

        /// <summary>
        /// Initializes Photo
        /// </summary>
        /// <param name="id">Photo Id</param>
        /// <param name="photoName">Photo Name</param>
        /// <param name="propertyId">Photo Property ID</param>
        public Photo(int photoID, string photoName, int photoProjectID)
        {
            _photoID = photoID;
            _photoName = photoName;
            _photoProjectID = photoProjectID;
        }


    }
}