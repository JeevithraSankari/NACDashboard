using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace NAC_Dashboard.Controllers.Models
{
    public class DataLayer
    {
        //IDbConnection idbCon;
        //IDbCommand idbCmd;
        //IDbDataParameter idbParam;
        //IDbDataAdapter idbAdapter;
        //IDataReader idbReader;


        SqlConnection idbCon;
        SqlCommand idbCmd;
        SqlParameter idbParam;
        SqlDataAdapter idbAdapter;
        SqlDataReader idbReader;

        DataSet ds;



        int loopI;


        private Boolean OpenConnection()
        {
            try
            {
                idbCon = new SqlConnection();
                idbCon.ConnectionString = ConfigurationManager.ConnectionStrings["FormulaConnectionStringTNagar"].ConnectionString;
                //idbCon.ConnectionString=ConfigurationManager.AppSettings["BEAMDB"];
                if (idbCon.State == ConnectionState.Open)
                    idbCon.Close();
                if ((idbCon.State == ConnectionState.Closed) || (idbCon.State == ConnectionState.Broken))
                {
                    idbCon.Open();
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }

        private Boolean OpenNACConnection()
        {
            try
            {
                idbCon = new SqlConnection();
                idbCon.ConnectionString = ConfigurationManager.ConnectionStrings["NACConnectionStringTNagar"].ConnectionString;               
                //idbCon.ConnectionString=ConfigurationManager.AppSettings["BEAMDB"];
                if (idbCon.State == ConnectionState.Open)
                    idbCon.Close();
                if ((idbCon.State == ConnectionState.Closed) || (idbCon.State == ConnectionState.Broken))
                {
                    idbCon.Open();
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }

        private Boolean OpenNACConnectionBank()
        {
            try
            {
                idbCon = new SqlConnection();
                idbCon.ConnectionString = ConfigurationManager.ConnectionStrings["NACConnectionStringBank"].ConnectionString;
                //idbCon.ConnectionString=ConfigurationManager.AppSettings["BEAMDB"];
                if (idbCon.State == ConnectionState.Open)
                    idbCon.Close();
                if ((idbCon.State == ConnectionState.Closed) || (idbCon.State == ConnectionState.Broken))
                {
                    idbCon.Open();
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }


        private void CloseConnection()
        {
            idbCon.Close();
        }




        public DataSet ExecSPDS(string spName, string[] paramName, SqlDbType[] paramType, string[] paramValue, Boolean useRemoveQuote)
        {
            try
            {
                if (OpenConnection())
                {
                    ds = new DataSet();

                    idbAdapter = new SqlDataAdapter(spName, idbCon);
                    idbAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    idbAdapter.SelectCommand.CommandTimeout = 120;
                    if (paramName != null)
                    {
                        for (int loopI = 0; loopI < paramName.Length; loopI++)
                        {
                            idbAdapter.SelectCommand.Parameters.Add(new SqlParameter(paramName[loopI], paramType[loopI]));

                            if (useRemoveQuote)
                                idbAdapter.SelectCommand.Parameters[paramName[loopI]].Value = RemoveQuote(paramValue[loopI]);
                            else
                                idbAdapter.SelectCommand.Parameters[paramName[loopI]].Value = paramValue[loopI];


                        }
                    }

                    idbAdapter.Fill(ds);
                    CloseConnection();
                    return ds;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet ExecSPDSNAC(string spName, string[] paramName, SqlDbType[] paramType, string[] paramValue, Boolean useRemoveQuote)
        {
            try
            {
                if (OpenNACConnection())
                {
                    //idbCmd = new SqlCommand();             
                    //idbCmd.CommandTimeout = 0;
                    ds = new DataSet();

                    idbAdapter = new SqlDataAdapter(spName, idbCon);
                    idbAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    idbAdapter.SelectCommand.CommandTimeout = 0;
                    if (paramName != null)
                    {
                        for (int loopI = 0; loopI < paramName.Length; loopI++)
                        {
                            idbAdapter.SelectCommand.Parameters.Add(new SqlParameter(paramName[loopI], paramType[loopI]));

                            if (useRemoveQuote)
                                idbAdapter.SelectCommand.Parameters[paramName[loopI]].Value = RemoveQuote(paramValue[loopI]);
                            else
                                idbAdapter.SelectCommand.Parameters[paramName[loopI]].Value = paramValue[loopI];


                        }
                    }

                    idbAdapter.Fill(ds);
                    CloseConnection();
                    return ds;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected DataTable ExecSPDT(string spName, string[] paramName, SqlDbType[] paramType, string[] paramValue, Boolean useRemoveQuote)
        {
            DataSet dsTemp = ExecSPDS(spName, paramName, paramType, paramValue, useRemoveQuote);
            if (dsTemp != null && dsTemp.Tables.Count > 0)
                return dsTemp.Tables[0];
            return null;
        }

        public String ExecSPStr(string spName, string[] paramName, SqlDbType[] paramType, string[] paramValue, Boolean useRemoveQuote)
        {
            DataSet dsTemp = ExecSPDS(spName, paramName, paramType, paramValue, useRemoveQuote);
            if (dsTemp != null && dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0)
                return dsTemp.Tables[0].Rows[0][0].ToString();
            return null;
        }



        public Int32 ExecSPInt(string spName, string[] paramName, SqlDbType[] paramType, string[] paramValue)
        {


            try
            {
                if (OpenConnection())
                {
                    idbCmd = new SqlCommand();
                    idbCmd.Connection = idbCon;
                    idbCmd.CommandTimeout = 900;
                    idbCmd.Parameters.Clear();
                    idbCmd.CommandType = CommandType.StoredProcedure;
                    idbCmd.CommandText = spName;

                    if (paramName != null)
                    {
                        for (loopI = 0; loopI < paramName.Length; loopI++)
                        {

                            //  blgen.convertDateTimeIn_MMDDYYYY_Format()
                            idbParam = new SqlParameter();
                            idbParam.SqlDbType = paramType[loopI];
                            paramValue[loopI] = paramValue[loopI] == null ? null : RemoveQuote(paramValue[loopI]);
                            idbParam.Direction = ParameterDirection.Input;
                            idbParam.ParameterName = paramName[loopI];
                            idbParam.Value = paramValue[loopI] != null ? paramValue[loopI] : "";
                            if (paramType[loopI] == SqlDbType.DateTime)
                                idbParam.Value = paramValue[loopI] != null ? paramValue[loopI] : "01/01/1900";
                            //else if (paramType[loopI] == SqlDbType.Image)
                            //    idbParam.Value = paramValue[loopI];

                            //idbParam.Value = paramValue[loopI] != null ? paramValue[loopI] : DBNull.Value;
                            idbCmd.Parameters.Add(idbParam);
                        }
                    }
                    idbParam = new SqlParameter("@transId", SqlDbType.Int);
                    idbParam.Direction = ParameterDirection.ReturnValue;
                    idbCmd.Parameters.Add(idbParam);
                    idbCmd.ExecuteNonQuery();
                    int transid = Convert.ToInt32(idbParam.Value);
                    CloseConnection();
                    return transid;
                }
                else
                    return -1;
            }
            catch (Exception)
            {
                return -1;
            }
        }



        public Int32 ExecSPInt(string spName, byte[] attachment, string[] paramName, SqlDbType[] paramType, string[] paramValue)
        {


            try
            {
                if (OpenConnection())
                {
                    idbCmd = new SqlCommand();
                    idbCmd.Connection = idbCon;
                    idbCmd.Parameters.Clear();
                    idbCmd.CommandType = CommandType.StoredProcedure;
                    idbCmd.CommandText = spName;
                    if (paramName != null)
                    {
                        for (loopI = 0; loopI < paramName.Length; loopI++)
                        {

                            //  blgen.convertDateTimeIn_MMDDYYYY_Format()
                            idbParam = new SqlParameter();
                            idbParam.SqlDbType = paramType[loopI];
                            paramValue[loopI] = paramValue[loopI] == null ? null : RemoveQuote(paramValue[loopI]);
                            idbParam.Direction = ParameterDirection.Input;
                            idbParam.ParameterName = paramName[loopI];
                            idbParam.Value = paramValue[loopI] != null ? paramValue[loopI] : "";
                            if (paramType[loopI] == SqlDbType.DateTime)
                                idbParam.Value = paramValue[loopI] != null ? paramValue[loopI] : "01/01/1900";
                            //else if (paramType[loopI] == SqlDbType.Image)
                            //    idbParam.Value = paramValue[loopI];

                            //idbParam.Value = paramValue[loopI] != null ? paramValue[loopI] : DBNull.Value;
                            idbCmd.Parameters.Add(idbParam);
                        }
                    }


                    //idbParam = new SqlParameter();
                    //idbParam.SqlDbType = SqlDbType.Image;
                    //idbParam.Value =  attachment;
                    //idbParam.Direction = ParameterDirection.Input;
                    //idbParam.ParameterName = "@Attachment";
                    //idbCmd.Parameters.Add(idbParam);



                    idbParam = new SqlParameter("@transId", SqlDbType.Int);
                    idbParam.Direction = ParameterDirection.ReturnValue;
                    idbCmd.Parameters.Add(idbParam);
                    idbCmd.ExecuteNonQuery();
                    int transid = Convert.ToInt32(idbParam.Value);
                    CloseConnection();
                    return transid;
                }
                else
                    return -1;
            }
            catch (Exception)
            {
                return -1;
            }
        }


        public Int32 ExecSPReimbursementAttachment(Int32 ReimbursementNo, string AttachFileName, string AttachFileType, byte[] Attachment, String AttachType)
        {
            try
            {
                if (OpenConnection())
                {
                    idbCmd = new SqlCommand("saveReimbursementAttachment", idbCon);
                    idbCmd.CommandType = CommandType.StoredProcedure;
                    idbCmd.Parameters.Add(new SqlParameter("@ReimbursementNo", SqlDbType.Int));
                    idbCmd.Parameters["@ReimbursementNo"].Value = ReimbursementNo;
                    idbCmd.Parameters.Add(new SqlParameter("@AttachFileName", SqlDbType.VarChar));
                    idbCmd.Parameters["@AttachFileName"].Value = AttachFileName;
                    idbCmd.Parameters.Add(new SqlParameter("@AttachFileType", SqlDbType.VarChar));
                    idbCmd.Parameters["@AttachFileType"].Value = AttachFileType;
                    idbCmd.Parameters.Add(new SqlParameter("@Attachment", SqlDbType.Image));
                    idbCmd.Parameters["@Attachment"].Value = Attachment;
                    idbCmd.Parameters.Add(new SqlParameter("@AttachType", SqlDbType.Char));
                    idbCmd.Parameters["@AttachType"].Value = AttachType;
                    idbCmd.ExecuteNonQuery();
                    CloseConnection();
                    return 1;
                }
                else
                    return -1;
            }
            catch (Exception)
            {
                return -1;
            }

        }

        public Int32 ExecSPEmployeeAttachment(String UserId, string AttachFileName, string AttachFileType, byte[] Attachment, String CreatedBy)
        {
            try
            {
                if (OpenConnection())
                {
                    idbCmd = new SqlCommand("saveEmployeeAttachment", idbCon);
                    idbCmd.CommandType = CommandType.StoredProcedure;
                    idbCmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
                    idbCmd.Parameters["@UserId"].Value = UserId;
                    idbCmd.Parameters.Add(new SqlParameter("@AttachFileName", SqlDbType.VarChar));
                    idbCmd.Parameters["@AttachFileName"].Value = AttachFileName;
                    idbCmd.Parameters.Add(new SqlParameter("@AttachFileType", SqlDbType.VarChar));
                    idbCmd.Parameters["@AttachFileType"].Value = AttachFileType;
                    idbCmd.Parameters.Add(new SqlParameter("@Attachment", SqlDbType.Image));
                    idbCmd.Parameters["@Attachment"].Value = Attachment;
                    idbCmd.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.Int));
                    idbCmd.Parameters["@CreatedBy"].Value = CreatedBy;
                    idbCmd.ExecuteNonQuery();
                    CloseConnection();
                    return 1;
                }
                else
                    return -1;
            }
            catch (Exception)
            {
                return -1;
            }

        }


        public String BulkUpload(DataTable dtData, string tableName)
        {
            try
            {
                if (OpenConnection())
                {
                    SqlBulkCopy sbc = new SqlBulkCopy(idbCon);

                    for (loopI = 0; loopI < dtData.Columns.Count; loopI++)
                        sbc.ColumnMappings.Add(dtData.Columns[loopI].ColumnName, dtData.Columns[loopI].ColumnName);

                    sbc.DestinationTableName = tableName;
                    sbc.WriteToServer(dtData.Select());
                    sbc.Close();
                    CloseConnection();
                    return "Data Saved";
                }
                return "Data Not Saved";
            }
            catch (Exception e)
            {
                return "Error: " + e.Message;
            }
        }

        public String RemoveQuote(string strValue)
        {
            return strValue.Replace("'", "''");
        }



        public DataTable ReadData(string spName, string[] paramName, SqlDbType[] paramType, string[] paramValue)
        {

            try
            {
                if (OpenConnection())
                {

                    idbCmd = new SqlCommand();
                    idbCmd.CommandTimeout = 900;
                    idbCmd.Connection = idbCon;
                    idbCmd.Parameters.Clear();
                    idbCmd.CommandType = CommandType.StoredProcedure;
                    idbCmd.CommandText = spName;
                    if (paramName != null)
                    {
                        for (loopI = 0; loopI < paramName.Length; loopI++)
                        {
                            idbParam = new SqlParameter();
                            idbParam.SqlDbType = paramType[loopI];
                            idbParam.Direction = ParameterDirection.Input;
                            idbParam.ParameterName = paramName[loopI];
                            if (paramValue[loopI] == null)
                                idbParam.Value = null;
                            else
                                idbParam.Value = RemoveQuote(paramValue[loopI]);
                            idbCmd.Parameters.Add(idbParam);
                        }
                    }

                    idbReader = idbCmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(idbReader);

                    if (!idbReader.IsClosed)
                    {
                        idbReader.Close();
                        idbReader.Dispose();
                    }
                    CloseConnection();
                    return dt;

                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {

            }






        }

        public DataTable ReadDataNAC(string spName, string[] paramName, SqlDbType[] paramType, string[] paramValue)
        {

            try
            {
                if (OpenNACConnection())
                {

                    idbCmd = new SqlCommand();
                    idbCmd.CommandTimeout = 900;
                    idbCmd.Connection = idbCon;
                    idbCmd.Parameters.Clear();
                    idbCmd.CommandType = CommandType.StoredProcedure;
                    idbCmd.CommandText = spName;
                    if (paramName != null)
                    {
                        for (loopI = 0; loopI < paramName.Length; loopI++)
                        {
                            idbParam = new SqlParameter();
                            idbParam.SqlDbType = paramType[loopI];
                            idbParam.Direction = ParameterDirection.Input;
                            idbParam.ParameterName = paramName[loopI];
                            if (paramValue[loopI] == null)
                                idbParam.Value = null;
                            else
                                idbParam.Value = RemoveQuote(paramValue[loopI]);
                            //idbParam.Value = paramValue[loopI];
                            idbCmd.Parameters.Add(idbParam);
                        }
                    }

                    idbReader = idbCmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(idbReader);

                    if (!idbReader.IsClosed)
                    {
                        idbReader.Close();
                        idbReader.Dispose();
                    }
                    CloseConnection();
                    return dt;

                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {

            }






        }

        public DataTable ReadDataNACBank(string spName, string[] paramName, SqlDbType[] paramType, string[] paramValue)
        {

            try
            {
                if (OpenNACConnectionBank())
                {

                    idbCmd = new SqlCommand();
                    idbCmd.CommandTimeout = 900;
                    idbCmd.Connection = idbCon;
                    idbCmd.Parameters.Clear();
                    idbCmd.CommandType = CommandType.StoredProcedure;
                    idbCmd.CommandText = spName;
                    if (paramName != null)
                    {
                        for (loopI = 0; loopI < paramName.Length; loopI++)
                        {
                            idbParam = new SqlParameter();
                            idbParam.SqlDbType = paramType[loopI];
                            idbParam.Direction = ParameterDirection.Input;
                            idbParam.ParameterName = paramName[loopI];
                            if (paramValue[loopI] == null)
                                idbParam.Value = null;
                            else
                                idbParam.Value = RemoveQuote(paramValue[loopI]);
                            //idbParam.Value = paramValue[loopI];
                            idbCmd.Parameters.Add(idbParam);
                        }
                    }

                    idbReader = idbCmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(idbReader);

                    if (!idbReader.IsClosed)
                    {
                        idbReader.Close();
                        idbReader.Dispose();
                    }
                    CloseConnection();
                    return dt;

                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {

            }






        }               

        public Int32 ExecSPIntNAC(string spName, string[] paramName, SqlDbType[] paramType, string[] paramValue)
        {


            try
            {
                if (OpenNACConnection())
                {
                    idbCmd = new SqlCommand();
                    idbCmd.Connection = idbCon;
                    idbCmd.CommandTimeout = 900;
                    idbCmd.Parameters.Clear();
                    idbCmd.CommandType = CommandType.StoredProcedure;
                    idbCmd.CommandText = spName;

                    if (paramName != null)
                    {
                        for (loopI = 0; loopI < paramName.Length; loopI++)
                        {

                            //  blgen.convertDateTimeIn_MMDDYYYY_Format()
                            idbParam = new SqlParameter();
                            idbParam.SqlDbType = paramType[loopI];
                            paramValue[loopI] = paramValue[loopI] == null ? null : RemoveQuote(paramValue[loopI]);
                            idbParam.Direction = ParameterDirection.Input;
                            idbParam.ParameterName = paramName[loopI];
                            idbParam.Value = paramValue[loopI] != null ? paramValue[loopI] : "";
                            if (paramType[loopI] == SqlDbType.DateTime)
                                idbParam.Value = paramValue[loopI] != null ? paramValue[loopI] : "01/01/1900";
                            //else if (paramType[loopI] == SqlDbType.Image)
                            //    idbParam.Value = paramValue[loopI];

                            //idbParam.Value = paramValue[loopI] != null ? paramValue[loopI] : DBNull.Value;
                            idbCmd.Parameters.Add(idbParam);
                        }
                    }
                    idbParam = new SqlParameter("@transId", SqlDbType.Int);
                    idbParam.Direction = ParameterDirection.ReturnValue;
                    idbCmd.Parameters.Add(idbParam);
                    idbCmd.ExecuteNonQuery();
                    int transid = Convert.ToInt32(idbParam.Value);
                    CloseConnection();
                    return transid;
                }
                else
                    return -1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public Int32 ExecSPIntNAC(string spName, byte[] attachment, string[] paramName, SqlDbType[] paramType, string[] paramValue)
        {


            try
            {
                if (OpenNACConnection())
                {
                    idbCmd = new SqlCommand();
                    idbCmd.Connection = idbCon;
                    idbCmd.Parameters.Clear();
                    idbCmd.CommandType = CommandType.StoredProcedure;
                    idbCmd.CommandText = spName;
                    if (paramName != null)
                    {
                        for (loopI = 0; loopI < paramName.Length; loopI++)
                        {

                            //  blgen.convertDateTimeIn_MMDDYYYY_Format()
                            idbParam = new SqlParameter();
                            idbParam.SqlDbType = paramType[loopI];
                            paramValue[loopI] = paramValue[loopI] == null ? null : RemoveQuote(paramValue[loopI]);
                            idbParam.Direction = ParameterDirection.Input;
                            idbParam.ParameterName = paramName[loopI];
                            idbParam.Value = paramValue[loopI] != null ? paramValue[loopI] : "";
                            if (paramType[loopI] == SqlDbType.DateTime)
                                idbParam.Value = paramValue[loopI] != null ? paramValue[loopI] : "01/01/1900";
                            //else if (paramType[loopI] == SqlDbType.Image)
                            //    idbParam.Value = paramValue[loopI];

                            //idbParam.Value = paramValue[loopI] != null ? paramValue[loopI] : DBNull.Value;
                            idbCmd.Parameters.Add(idbParam);
                        }
                    }


                    //idbParam = new SqlParameter();
                    //idbParam.SqlDbType = SqlDbType.Image;
                    //idbParam.Value =  attachment;
                    //idbParam.Direction = ParameterDirection.Input;
                    //idbParam.ParameterName = "@Attachment";
                    //idbCmd.Parameters.Add(idbParam);



                    idbParam = new SqlParameter("@transId", SqlDbType.Int);
                    idbParam.Direction = ParameterDirection.ReturnValue;
                    idbCmd.Parameters.Add(idbParam);
                    idbCmd.ExecuteNonQuery();
                    int transid = Convert.ToInt32(idbParam.Value);
                    CloseConnection();
                    return transid;
                }
                else
                    return -1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public int SaveEmpImage(byte[] Photo, byte[] Signature, string UserID, String SpName)
        {
            try
            {
                if (OpenConnection())
                {
                    idbCmd = new SqlCommand(SpName, idbCon);
                    idbCmd.CommandType = CommandType.StoredProcedure;
                    idbCmd.Parameters.Add(new SqlParameter("@Photo", SqlDbType.Image));
                    idbCmd.Parameters["@Photo"].Value = Photo;
                    idbCmd.Parameters.Add(new SqlParameter("@Signature", SqlDbType.Image));
                    idbCmd.Parameters["@Signature"].Value = Signature;
                    idbCmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
                    idbCmd.Parameters["@UserId"].Value = UserID;

                    Int16 RetValue = Convert.ToInt16(idbCmd.ExecuteScalar());
                    idbCon.Close();
                    return RetValue;
                }
                else
                    return -1;

            }
            catch (Exception ex)
            {
                String Msg = ex.Message;
                return -1;
            }
        }




        public DataSet ExecuteSelectQry(String query)
        {
            try
            {
                if (OpenConnection())
                {
                    ds = new DataSet();
                    idbAdapter = new SqlDataAdapter(query, idbCon);
                    idbAdapter.Fill(ds);
                    CloseConnection();
                }
                return ds;
            }
            catch
            {
                return null;
            }
        }
    }

    public class Getdata
    {

        public string CampaignName { get; set; }


        public string BrandName { get; set; }

        public string Category { get; set; }


    }

    public class businesslayer
    {
        DataLayer ds = new DataLayer();

        public Int32 savetxt(String CampaignName, String BrandName, String Category)
        {
            String[] ParamName = { "@CampaignName", "@BrandName", "@Category" };
            SqlDbType[] ParamType = { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };
            String[] ParamValue = { CampaignName, BrandName, Category };
            return ds.ExecSPInt("savetxt", ParamName, ParamType, ParamValue);
        }

    }

}