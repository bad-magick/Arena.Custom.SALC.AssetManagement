using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using Arena.Core;
using Arena.DataLib;

namespace Arena.Custom.SALC.AssetManagement
{

    /// <summary>
    /// Default data values for successful Arena integration.
    /// </summary>
    public class DefaultValues
    {
        public static DateTime MinDate()
        {
            return new DateTime(1901, 1, 1);
        }

        public static DateTime MaxDate()
        {
            return new DateTime(2199, 12, 31);
        }
    }

    /// <summary>
    /// Object class for holding asset type data.
    /// </summary>
    [Serializable]
    public class AssetType : ArenaObjectBase
    {

        #region Private Data

        private int iTypeId = 0;
        private string sName = string.Empty;
        private string sDescription = string.Empty;

        #endregion

        #region Public Properties

        public int TypeId
        {
            get { return iTypeId; }
        }

        public string Name
        {
            get { return sName; }
        }

        public string Description
        {
            get { return sDescription; }
        }

        #endregion

        #region Constructors

        internal AssetType(int typeId, string name, string description)
        {
            iTypeId = typeId;
            sName = name;
            sDescription = description;
        }

        #endregion
    }

    /// <summary>
    /// Object class for holding a collection of AssetType objects.
    /// </summary>
    public class AssetTypeCollection : ArenaCollectionBase
    {

        #region Public Methods

        public void Add(AssetType assetType)
        {
            this.List.Add(assetType);
        }

        public void Insert(int index, AssetType assetType)
        {
            this.List.Insert(index, assetType);
        }

        /// <summary>
        /// Returns an AssetType object with the specified TypeId if it exists. Otherwise, null is returned.
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public AssetType FindById(int typeId)
        {
            foreach (AssetType a in this.List)
            {
                if (a.TypeId == typeId)
                {
                    return a;
                }
            }
            return null;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a collection based on standard values.
        /// </summary>
        public AssetTypeCollection()
        {
            this.Add(new AssetType(0, "Building", "A building."));
            this.Add(new AssetType(1, "Bathroom", "A bathroom."));
            this.Add(new AssetType(2, "Hallway", "A hallway."));
            this.Add(new AssetType(3, "Entry", "An entry to a building."));
            this.Add(new AssetType(4, "Room", "A room in a building."));
            this.Add(new AssetType(5, "Classroom", "A classroom in a building."));
            this.Add(new AssetType(6, "Office", "An office in a building."));
            this.Add(new AssetType(7, "Mechanical Room", "A mechanical room in a building."));
            this.Add(new AssetType(8, "Electrical Room", "An electrical room in a building."));
            this.Add(new AssetType(9, "Pastor Office", "A pastor's office."));
            this.Add(new AssetType(10, "Outside Asset", "An asset outside of a building."));
            this.Add(new AssetType(11, "Flat Roof", "A flat roof with no pitch."));
            this.Add(new AssetType(12, "Pitched Roof", "A pitched roof."));
            this.Add(new AssetType(14, "Inside Area", "Any larger area in a building that contains other rooms, hallways or offices."));
            this.Add(new AssetType(15, "Worship", "A pitched roof."));
            this.Add(new AssetType(16, "Custodial Room", "A pitched roof."));
            this.Add(new AssetType(17, "HVAC", "An HVAC asset."));
            this.Add(new AssetType(18, "Truck", "A truck."));
            this.Add(new AssetType(19, "Power Tool", "A power tool."));
            this.Add(new AssetType(20, "Furniture", "A furniture asset."));
            this.Add(new AssetType(21, "Machine", ""));
            this.Add(new AssetType(22, "Heavy Equipment", ""));
            this.Add(new AssetType(23, "Storage Room", "A room dedicated to storage."));
        }

        #endregion

    }

    /// <summary>
    /// An object that holds the status information for a given asset.
    /// </summary>
    [Serializable]
    public class AssetStatus : ArenaObjectBase
    {

        #region Private Data

        private int iStatusId = 0;
        private string sName = string.Empty;
        private string sDescription = string.Empty;

        #endregion

        #region Public Properties

        public int StatusId
        {
            get { return iStatusId; }
            set { iStatusId = value; }
        }

        public string Name
        {
            get { return sName; }
            set { sName = value; }
        }

        public string Description
        {
            get { return sDescription; }
            set { sDescription = value; }
        }

        #endregion

        #region Constructors

        internal AssetStatus(int statusId, string name, string description)
        {
            iStatusId = statusId;
            sName = name;
            sDescription = description;
        }

        #endregion

    }

    /// <summary>
    /// An object that contains a list of asset statuses.
    /// </summary>
    public class AssetStatusCollection : ArenaCollectionBase
    {

        #region Public Methods

        public void Add(AssetStatus assetStatus)
        {
            this.List.Add(assetStatus);
        }

        public void Insert(int index, AssetStatus assetStatus)
        {
            this.List.Insert(index, assetStatus);
        }

        /// <summary>
        /// Finds a status object within the collection that matches a given StatusId.
        /// </summary>
        /// <param name="statusId"></param>
        /// <returns></returns>
        public AssetStatus FindById(int statusId)
        {
            foreach (AssetStatus a in this.List)
            {
                if (a.StatusId == statusId)
                {
                    return a;
                }
            }
            return null;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates the default list AssetStatus objects.
        /// </summary>
        public AssetStatusCollection()
        {
            this.Add(new AssetStatus(0, "Inactive", "Inactive asset."));
            this.Add(new AssetStatus(1, "Active", "Active asset."));
            this.Add(new AssetStatus(3, "Unknown", "Unknown status."));
            this.Add(new AssetStatus(4, "Not Installed", "Asset not yet insalled."));
            this.Add(new AssetStatus(5, "On Order", "Asset is currently on-order with supplier."));
            this.Add(new AssetStatus(6, "Sold", "Asset has been sold."));
            this.Add(new AssetStatus(7, "Scrapped", "Asset has been scrapped."));
            this.Add(new AssetStatus(8, "Under Construction", "Asset is currently under construction."));
        }

        #endregion

    }

    /// <summary>
    /// Object class for creating, storing, and accessing data for an individual asset.
    /// </summary>
    [Serializable]
    public class Asset : SqlData
    {

        #region Private Data

        private int iAssetId = 0;  //An AssetId with a value of 0 is invalid, since 0 is reserved for the Organization and has no actual data entry. The information is populated from Arena objects.
        private int iParentId = 0; //A ParentId with a value of 0 is refering to the Organization as a whole.
        private bool bIsReal = false;
        private int iTypeId = 0;
        private int iCategoryId = 0;
        private int iGroupId = 0;
        private int iBudgetId = 0;
        private int iSaleVendorId = 0;
        private int iInstallVendorId = 0;
        private int iStatusId = 0;
        private int iLocation = 0; //Id of asset that serves as the location of the specified asset.
        private bool bActive = false;
        private string sName = string.Empty;
        private string sDescription = string.Empty;
        private string sManufacturer = string.Empty;
        private string sModel = string.Empty;
        private string sSerialNumber = string.Empty;
        private DateTime dtAcquisition = DefaultValues.MinDate();
        private DateTime dtInstall = DefaultValues.MinDate();
        private DateTime dtDecommission = DefaultValues.MinDate();
        private DateTime dtWarrantyExpiration = DefaultValues.MinDate();
        private string sWarranty = string.Empty;
        private decimal dSizeX = 0;
        private decimal dSizeY = 0;
        private string sPaintCode = string.Empty;
        private string sNotes = string.Empty;
        private int iOrganizationId = 1;
        private byte[] blobImage = null;

        #endregion

        #region Public Properties

        public int AssetId
        {
            get { return iAssetId; }
            set { iAssetId = value; }
        }

        public Asset Parent
        {
            get
            {
                if (iParentId > 0)
                {
                    return new Asset(iParentId);
                }
                else
                {
                    return null;
                }
            }
        }

        public int ParentId
        {
            get { return iParentId; }
            set { iParentId = value; }
        }

        public bool IsReal
        {
            get { return bIsReal; }
            set { bIsReal = value; }
        }

        public int TypeId
        {
            get { return iTypeId; }
            set { iTypeId = value; }
        }

        public int CategoryId
        {
            get { return iCategoryId; }
            set { iCategoryId = value; }
        }

        public int GroupId
        {
            get { return iGroupId; }
            set { iGroupId = value; }
        }

        public int BudgetId
        {
            get { return iBudgetId; }
            set { iBudgetId = value; }
        }

        public int SaleVendorId
        {
            get { return iSaleVendorId; }
            set { iSaleVendorId = value; }
        }

        public int InstallVendorId
        {
            get { return iInstallVendorId; }
            set { iInstallVendorId = value; }
        }

        public int StatusId
        {
            get { return iStatusId; }
            set { iStatusId = value; }
        }

        public int Location
        {
            get { return iLocation; }
            set { iLocation = value; }
        }

        public bool Active
        {
            get { return bActive; }
            set { bActive = value; }
        }

        public string Name
        {
            get { return sName; }
            set { sName = value; }
        }

        public string Description
        {
            get { return sDescription; }
            set { sDescription = value; }
        }

        public string Manufacturer
        {
            get { return sManufacturer; }
            set { sManufacturer = value; }
        }

        public string Model
        {
            get { return sModel; }
            set { sModel = value; }
        }

        public string SerialNumber
        {
            get { return sSerialNumber; }
            set { sSerialNumber = value; }
        }

        public DateTime Acquisition
        {
            get { return dtAcquisition; }
            set { dtAcquisition = value; }
        }

        public DateTime Install
        {
            get { return dtInstall; }
            set { dtInstall = value; }
        }

        public DateTime Decommission
        {
            get { return dtDecommission; }
            set { dtDecommission = value; }
        }

        public DateTime WarrantyExpiration
        {
            get { return dtWarrantyExpiration; }
            set { dtWarrantyExpiration = value; }
        }

        public string WarrantyInformation
        {
            get { return sWarranty; }
            set { sWarranty = value; }
        }

        public decimal SizeX
        {
            get { return dSizeX; }
            set { dSizeX = value; }
        }

        public decimal SizeY
        {
            get { return dSizeY; }
            set { dSizeY = value; }
        }

        public string PaintCode
        {
            get { return sPaintCode; }
            set { sPaintCode = value; }
        }

        public string Notes
        {
            get { return sNotes; }
            set { sNotes = value; }
        }

        public int OrganizationId
        {
            get { return iOrganizationId; }
            set { iOrganizationId = value; }
        }

        public byte[] Image
        {
            get { return blobImage; }
            set { blobImage = value; }
        }

        #endregion

        #region Constructors

        public Asset() { }

        /// <summary>
        /// Creates an Asset object loading the information from the specified AssetID
        /// </summary>
        /// <param name="assetId"></param>
        public Asset(int assetId)
        {
            SqlDataReader reader = new Asset().GetById(assetId);
            if (reader.Read())
            {
                LoadData(reader);
            }
            reader.Close();
        }

        /// <summary>
        /// Creates an Asset object loading the information from the specified SqlDataReader object
        /// </summary>
        /// <param name="reader"></param>
        internal Asset(SqlDataReader reader)
        {
            LoadData(reader);
        }

        #endregion

        #region Private Functions

        private SqlDataReader GetById(int id)
        {
            ArrayList lst = new ArrayList();
            lst.Add(new SqlParameter("@id", id));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_am_getbyid_asset", lst);
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }

        private void LoadData(SqlDataReader reader)
        {
            iAssetId = (int)reader["asset_id"];
            iParentId = (int)reader["parent_id"];
            bIsReal = (bool)reader["real"];
            iTypeId = (int)reader["type_id"];
            iCategoryId = (int)reader["category_id"];
            iGroupId = (int)reader["group_id"];
            iBudgetId = (int)reader["budget_id"];
            iSaleVendorId = (int)reader["sale_vendor_id"];
            iInstallVendorId = (int)reader["install_vendor_id"];
            iStatusId = (int)reader["asset_status_id"];
            iLocation = (int)reader["location_id"];
            bActive = (bool)reader["active"];
            sName = reader["name"].ToString();
            sDescription = reader["description"].ToString();
            sManufacturer = reader["manufacturer"].ToString();
            sModel = reader["model"].ToString();
            sSerialNumber = reader["serial_number"].ToString();
            dtAcquisition = (DateTime)reader["acquisition_date"];
            dtInstall = (DateTime)reader["install_date"];
            dtDecommission = (DateTime)reader["decommission_date"];
            dtWarrantyExpiration = (DateTime)reader["warranty_expiration_date"];
            sWarranty = reader["warranty_info"].ToString();
            dSizeX = (decimal)reader["size_x"];
            dSizeY = (decimal)reader["size_y"];
            sPaintCode = reader["paint_code"].ToString();
            sNotes = reader["notes"].ToString();
            iOrganizationId = (int)reader["organization_id"];

            if (!reader.IsDBNull(reader.GetOrdinal("image")))
                blobImage = (byte[])reader["image"];
        }

        private void DeleteData(int id)
        {
            ArrayList lst = new ArrayList();
            lst.Add(new SqlParameter("@id", id));

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_am_del_asset", lst);
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }

        internal SqlDataReader LoadAllByParent(int orgId, int parentId, bool isReal)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@ParentId", parentId));
            lst.Add(new SqlParameter("@OrganizationId", orgId));
            lst.Add(new SqlParameter("@Real", isReal));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_am_getall_asset", lst);
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                lst = null;
            }
        }

        internal SqlDataReader LoadAllByTypeId(int orgId, int typeId)
        {
            ArrayList lst = new ArrayList();



            lst.Add(new SqlParameter("@TypeId", typeId));
            lst.Add(new SqlParameter("@OrganizationId", orgId));

            try
            {
                return this.ExecuteSqlDataReader("cust_sp_salc_am_getall_asset", lst);
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                lst = null;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Saves the current Asset object to the SQL database. Returns the AssetId of the saved or newly created database entry.
        /// </summary>
        /// <param name="userId"></param>
        public int Save(string userId)
        {
            ArrayList lst = new ArrayList();

            lst.Add(new SqlParameter("@AssetId", iAssetId));
            lst.Add(new SqlParameter("@ParentId", iParentId));
            lst.Add(new SqlParameter("@Real", bIsReal));
            lst.Add(new SqlParameter("@TypeId", iTypeId));
            lst.Add(new SqlParameter("@CategoryId", iCategoryId));
            lst.Add(new SqlParameter("@GroupId", iGroupId));
            lst.Add(new SqlParameter("@BudgetId", iBudgetId));
            lst.Add(new SqlParameter("@SaleVendorId", iSaleVendorId));
            lst.Add(new SqlParameter("@InstallVendorId", iInstallVendorId));
            lst.Add(new SqlParameter("@Status", iStatusId));
            lst.Add(new SqlParameter("@Location", iLocation));
            lst.Add(new SqlParameter("@Active", bActive));
            lst.Add(new SqlParameter("@Name", sName));
            lst.Add(new SqlParameter("@Description", sDescription));
            lst.Add(new SqlParameter("@Manufacturer", sManufacturer));
            lst.Add(new SqlParameter("@Model", sModel));
            lst.Add(new SqlParameter("@SerialNumber", sSerialNumber));
            lst.Add(new SqlParameter("@AcquisitionDate", dtAcquisition));
            lst.Add(new SqlParameter("@InstallDate", dtInstall));
            lst.Add(new SqlParameter("@DecommissionDate", dtDecommission));
            lst.Add(new SqlParameter("@WarrantyExpirationDate", dtWarrantyExpiration));
            lst.Add(new SqlParameter("@WarrantyInfo", sWarranty));
            lst.Add(new SqlParameter("@SizeX", dSizeX));
            lst.Add(new SqlParameter("@SizeY", dSizeY));
            lst.Add(new SqlParameter("@PaintCode", sPaintCode));
            lst.Add(new SqlParameter("@Notes", sNotes));
            lst.Add(new SqlParameter("@OrganizationId", iOrganizationId));
            lst.Add(new SqlParameter("@Image", blobImage));

            SqlParameter spOut = new SqlParameter("@ID", SqlDbType.Int);
            spOut.Direction = ParameterDirection.Output;
            lst.Add(spOut);

            try
            {
                this.ExecuteNonQuery("cust_sp_salc_am_save_asset", lst);
                iAssetId = Convert.ToInt32(((SqlParameter)(lst[lst.Count - 1])).Value.ToString());
                return iAssetId;
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Deletes the current Asset object from the database. The object remains valid.
        /// </summary>
        public void Delete()
        {
            DeleteData(iAssetId);
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Deletes Asset object from the database with the specified AssetId.
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(int id)
        {
            new Asset(id).Delete();
        }

        #endregion

    }

    /// <summary>
    /// Object class for parsing a collection of Asset objects.
    /// </summary>
    public class AssetCollection : ArenaCollectionBase
    {

        #region Public Methods

        public void Add(Asset asset)
        {
            this.List.Add(asset);
        }

        public void Insert(int index, Asset asset)
        {
            this.List.Insert(index, asset);
        }

        #endregion

        #region Constructors

        private AssetCollection()
        {
        }

        /// <summary>
        /// Creates a collection of all assets with the specified parent.
        /// </summary>
        /// <param name="parentId"></param>
        public AssetCollection(int orgId, int parentId, bool real)
        {
            SqlDataReader reader = new Asset().LoadAllByParent(orgId, parentId, real);
            while (reader.Read())
            {
                this.Add(new Asset(reader));
            }
        }

        public AssetCollection(int orgId, int typeId)
        {
            SqlDataReader reader = new Asset().LoadAllByTypeId(orgId, typeId);
            while (reader.Read())
            {
                this.Add(new Asset(reader));
            }
        }

        #endregion

    }

}
