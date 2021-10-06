using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using yo_lib;

/// <summary>
///     Summary description for DBEmployerClass
/// </summary>
public class DBEmployerClass
{
    private SqlCommand objCommand;
    private SqlConnection objConnection;
    private SqlDataReader objReader;

    public string strDBError = null;

    internal int fn_saveEmployer(EmployerClass objEmployer)
    {
        try
        {
            objConnection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand =
                new SqlCommand(
                    "INSERT INTO edu_Employer(emp_accType, emp_fname, emp_lname, emp_email, emp_password, emp_company, emp_pincode, emp_city, emp_country, emp_designation, emp_phone, emp_website, emp_companydetails, emp_industry, emp_industryType, emp_total, emp_regdate) VALUES (@emp_accType, @emp_fname, @emp_lname, @emp_email, @emp_password, @emp_company, @emp_pincode, @emp_city, @emp_country, @emp_designation, @emp_phone, @emp_website, @emp_companydetails, @emp_industry, @emp_industryType, @emp_total, @emp_regdate);SELECT @PK_New = @@IDENTITY",
                    objConnection);

            var insertedKey = new SqlParameter("@PK_New", SqlDbType.Int);
            insertedKey.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(insertedKey);

            objCommand.Parameters.AddWithValue("@emp_accType", objEmployer.strAccType);
            objCommand.Parameters.AddWithValue("@emp_fname", objEmployer.strFName);
            objCommand.Parameters.AddWithValue("@emp_lname", objEmployer.strLName);
            objCommand.Parameters.AddWithValue("@emp_email", objEmployer.strEmail);
            objCommand.Parameters.AddWithValue("@emp_password", objEmployer.strPassword);
            objCommand.Parameters.AddWithValue("@emp_company", objEmployer.strCompany);
            objCommand.Parameters.AddWithValue("@emp_pincode", objEmployer.strPincode);
            objCommand.Parameters.AddWithValue("@emp_city", objEmployer.strCity);
            objCommand.Parameters.AddWithValue("@emp_country", objEmployer.strCountry);
            objCommand.Parameters.AddWithValue("@emp_designation", objEmployer.strDesignation);
            objCommand.Parameters.AddWithValue("@emp_phone", objEmployer.strPhone);
            objCommand.Parameters.AddWithValue("@emp_website", objEmployer.strWebsite);

            objCommand.Parameters.AddWithValue("@emp_companydetails", objEmployer.strCompanyDetails);
            objCommand.Parameters.AddWithValue("@emp_industry", objEmployer.strIndustry);
            objCommand.Parameters.AddWithValue("@emp_industryType", objEmployer.strIndustryType);
            objCommand.Parameters.AddWithValue("@emp_total", objEmployer.iEmpTotal);

            objCommand.Parameters.AddWithValue("@emp_active", objEmployer.bActivate);
            objCommand.Parameters.AddWithValue("@emp_regdate", DateTime.Now);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                int iUserID = int.Parse(objCommand.Parameters["@PK_New"].Value.ToString());
                return iUserID;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    internal string fn_editEmployer(EmployerClass objEmployer)
    {
        try
        {
            objConnection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand =
                new SqlCommand(
                    "UPDATE edu_Employer SET emp_accType=@emp_accType, emp_fname=@emp_fname, emp_lname=@emp_lname, emp_company=@emp_company, emp_pincode=@emp_pincode, emp_city=@emp_city, emp_country=@emp_country, emp_designation=@emp_designation, emp_phone=@emp_phone, emp_website=@emp_website, emp_companydetails=@emp_companydetails, emp_industry=@emp_industry, emp_industryType=@emp_industryType, emp_total=@emp_total WHERE emp_ID=@emp_ID",
                    objConnection);

            objCommand.Parameters.AddWithValue("@emp_ID", objEmployer.iID);

            objCommand.Parameters.AddWithValue("@emp_accType", objEmployer.strAccType);
            objCommand.Parameters.AddWithValue("@emp_fname", objEmployer.strFName);
            objCommand.Parameters.AddWithValue("@emp_lname", objEmployer.strLName);
            objCommand.Parameters.AddWithValue("@emp_company", objEmployer.strCompany);
            objCommand.Parameters.AddWithValue("@emp_pincode", objEmployer.strPincode);
            objCommand.Parameters.AddWithValue("@emp_city", objEmployer.strCity);
            objCommand.Parameters.AddWithValue("@emp_country", objEmployer.strCountry);
            objCommand.Parameters.AddWithValue("@emp_designation", objEmployer.strDesignation);
            objCommand.Parameters.AddWithValue("@emp_phone", objEmployer.strPhone);
            objCommand.Parameters.AddWithValue("@emp_website", objEmployer.strWebsite);

            objCommand.Parameters.AddWithValue("@emp_companydetails", objEmployer.strCompanyDetails);
            objCommand.Parameters.AddWithValue("@emp_industry", objEmployer.strIndustry);
            objCommand.Parameters.AddWithValue("@emp_industryType", objEmployer.strIndustryType);
            objCommand.Parameters.AddWithValue("@emp_total", objEmployer.iEmpTotal);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record updated successfully";
            }
            else
            {
                return "ERROR : SQL Exception";
            }
        }
        catch (Exception ex)
        {
            return "ERROR : " + ex.Message;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    internal string fn_deleteEmployer(EmployerClass objEmployer)
    {
        try
        {
            objConnection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("DELETE FROM edu_Employer WHERE emp_ID = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", objEmployer.iID);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been deleted";
            }
            else
            {
                return "ERROR : SQL Exception";
            }
        }
        catch (Exception ex)
        {
            return "ERROR : " + ex.Message;
        }
        finally
        {
            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    internal CoreWebList<EmployerClass> fn_getEmployerByID(EmployerClass objEmployer)
    {
        CoreWebList<EmployerClass> objEmployerInfoList = null;
        EmployerClass objEmployerInfo = null;
        try
        {
            objConnection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_Employer WHERE emp_ID = @ID", objConnection);
            objCommand.Parameters.AddWithValue("@ID", objEmployer.iID);
            objReader = objCommand.ExecuteReader();

            objEmployerInfoList = new CoreWebList<EmployerClass>();

            if (objReader.Read())
            {
                objEmployerInfo = new EmployerClass();
                objEmployerInfo.iID = int.Parse(objReader["emp_ID"].ToString());
                objEmployerInfo.strAccType = objReader["emp_accType"].ToString();
                objEmployerInfo.strFName = objReader["emp_fname"].ToString();
                objEmployerInfo.strLName = objReader["emp_lname"].ToString();

                objEmployerInfo.strEmail = objReader["emp_email"].ToString();
                objEmployerInfo.strPassword = objReader["emp_password"].ToString();

                objEmployerInfo.strCompany = objReader["emp_company"].ToString();
                objEmployerInfo.strPincode = objReader["emp_pincode"].ToString();
                objEmployerInfo.strCity = objReader["emp_city"].ToString();
                objEmployerInfo.strCountry = objReader["emp_country"].ToString();
                objEmployerInfo.strDesignation = objReader["emp_designation"].ToString();
                objEmployerInfo.strPhone = objReader["emp_phone"].ToString();

                objEmployerInfo.strWebsite = objReader["emp_website"].ToString();
                objEmployerInfo.strCompanyDetails = objReader["emp_companydetails"].ToString();
                objEmployerInfo.strIndustry = objReader["emp_industry"].ToString();
                objEmployerInfo.strIndustryType = objReader["emp_industryType"].ToString();
                objEmployerInfo.iEmpTotal = int.Parse(objReader["emp_total"].ToString());

                objEmployerInfo.bActivate = Convert.ToBoolean(objReader["emp_active"].ToString());
                objEmployerInfo.dtRegisterDate = Convert.ToDateTime(objReader["emp_regdate"].ToString());

                objEmployerInfoList.Add(objEmployerInfo);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objEmployerInfoList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objReader != null)
            {
                objReader.Close();
            }

            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    internal CoreWebList<EmployerClass> fn_getEmployerList()
    {
        CoreWebList<EmployerClass> objEmployerInfoList = null;
        EmployerClass objEmployerInfo = null;
        try
        {
            objConnection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_Employer", objConnection);

            objReader = objCommand.ExecuteReader();

            objEmployerInfoList = new CoreWebList<EmployerClass>();

            while (objReader.Read())
            {
                objEmployerInfo = new EmployerClass();

                objEmployerInfo = new EmployerClass();
                objEmployerInfo.iID = int.Parse(objReader["emp_ID"].ToString());
                objEmployerInfo.strAccType = objReader["emp_accType"].ToString();
                objEmployerInfo.strFName = objReader["emp_fname"].ToString();
                objEmployerInfo.strLName = objReader["emp_lname"].ToString();

                objEmployerInfo.strEmail = objReader["emp_email"].ToString();
                objEmployerInfo.strPassword = objReader["emp_password"].ToString();

                objEmployerInfo.strCompany = objReader["emp_company"].ToString();
                objEmployerInfo.strPincode = objReader["emp_pincode"].ToString();
                objEmployerInfo.strCity = objReader["emp_city"].ToString();
                objEmployerInfo.strCountry = objReader["emp_country"].ToString();
                objEmployerInfo.strDesignation = objReader["emp_designation"].ToString();
                objEmployerInfo.strPhone = objReader["emp_phone"].ToString();

                objEmployerInfo.strWebsite = objReader["emp_website"].ToString();
                objEmployerInfo.strCompanyDetails = objReader["emp_companydetails"].ToString();
                objEmployerInfo.strIndustry = objReader["emp_industry"].ToString();
                objEmployerInfo.strIndustryType = objReader["emp_industryType"].ToString();
                objEmployerInfo.iEmpTotal = int.Parse(objReader["emp_total"].ToString());

                objEmployerInfo.bActivate = Convert.ToBoolean(objReader["emp_active"].ToString());
                objEmployerInfo.dtRegisterDate = Convert.ToDateTime(objReader["emp_regdate"].ToString());

                objEmployerInfoList.Add(objEmployerInfo);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objEmployerInfoList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objReader != null)
            {
                objReader.Close();
            }

            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    internal string fn_changeUserActivateStatus(EmployerClass objEmployer)
    {
        try
        {
            objConnection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);
            objConnection.Open();

            objCommand = new SqlCommand("UPDATE edu_Employer SET emp_active = @bActivate WHERE emp_ID = @ID ",
                objConnection);

            objCommand.Parameters.AddWithValue("@bActivate", objEmployer.bActivate);
            objCommand.Parameters.AddWithValue("@ID", objEmployer.iID);

            if (objCommand.ExecuteNonQuery() > 0)
            {
                return "SUCCESS : Record has been updated";
            }
            else
            {
                return "ERROR : SQL Exception";
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            if (objReader != null)
            {
                objReader.Close();
            }

            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    internal CoreWebList<EmployerClass> fn_checkLogin(EmployerClass objEmployer)
    {
        try
        {
            CoreWebList<EmployerClass> objEmployerInfoList = null;
            EmployerClass objEmployerInfo = null;

            objConnection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("select * from edu_Employer where emp_email = @eMail and emp_password = @pwd",
                objConnection);
            objCommand.Parameters.AddWithValue("@eMail", objEmployer.strEmail);
            objCommand.Parameters.AddWithValue("@pwd", objEmployer.strPassword);
            objReader = objCommand.ExecuteReader();

            objEmployerInfoList = new CoreWebList<EmployerClass>();

            while (objReader.Read())
            {
                objEmployerInfo = new EmployerClass();
                objEmployerInfo.iID = int.Parse(objReader["emp_ID"].ToString());
                objEmployerInfo.strAccType = objReader["emp_accType"].ToString();
                objEmployerInfo.strFName = objReader["emp_fname"].ToString();
                objEmployerInfo.strLName = objReader["emp_lname"].ToString();

                objEmployerInfo.strEmail = objReader["emp_email"].ToString();
                objEmployerInfo.strPassword = objReader["emp_password"].ToString();

                objEmployerInfo.strCompany = objReader["emp_company"].ToString();
                objEmployerInfo.strPincode = objReader["emp_pincode"].ToString();
                objEmployerInfo.strCity = objReader["emp_city"].ToString();
                objEmployerInfo.strCountry = objReader["emp_country"].ToString();
                objEmployerInfo.strDesignation = objReader["emp_designation"].ToString();
                objEmployerInfo.strPhone = objReader["emp_phone"].ToString();

                objEmployerInfo.strWebsite = objReader["emp_website"].ToString();
                objEmployerInfo.strCompanyDetails = objReader["emp_companydetails"].ToString();
                objEmployerInfo.strIndustry = objReader["emp_industry"].ToString();
                objEmployerInfo.strIndustryType = objReader["emp_industryType"].ToString();
                objEmployerInfo.iEmpTotal = int.Parse(objReader["emp_total"].ToString());

                objEmployerInfo.bActivate = Convert.ToBoolean(objReader["emp_active"].ToString());
                objEmployerInfo.dtRegisterDate = Convert.ToDateTime(objReader["emp_regdate"].ToString());

                objEmployerInfoList.Add(objEmployerInfo);
            }

            if (objReader != null)
            {
                objReader.Close();
            }

            return objEmployerInfoList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objReader != null)
            {
                objReader.Close();
            }

            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
    }

    internal bool fn_checkEmail(EmployerClass objEmployer)
    {
        CoreWebList<EmployerClass> objEmployerMasterList = null;
        EmployerClass objEmployerMaster = null;
        bool chkEmail = false;
        try
        {
            objConnection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["eduConnectionString"].ConnectionString);

            objConnection.Open();

            objCommand = new SqlCommand("SELECT * FROM edu_Employer WHERE emp_email = @email", objConnection);

            objCommand.Parameters.AddWithValue("@email", objEmployer.strEmail);
            objReader = objCommand.ExecuteReader();
            objEmployerMasterList = new CoreWebList<EmployerClass>();
            if (objReader.Read())
            {
                chkEmail = true;
                objEmployerMasterList.Add(objEmployerMaster);
            }
            else
            {
                chkEmail = false;
            }

            if (objReader != null)
            {
                objReader.Close();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (objReader != null)
            {
                objReader.Close();
            }

            if (objConnection != null)
            {
                objConnection.Close();
            }
        }
        return chkEmail;
    }
}