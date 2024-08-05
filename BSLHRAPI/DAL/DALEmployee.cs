using BSLHRAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BSLHRAPI.DAL
{
    public class DALEmployee
    {
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["BSL"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataSet ds;

        public clsEmployee Fn_Add_Employee(clsEmployee objReq)
        {
            var objResp = new clsEmployee();
            try
            {
                if (objReq.EmpId != null || objReq.EmpId != 0)
                {
                    objResp.vErrorMsg = "Please Enter User Id.";
                }
                else if (String.IsNullOrWhiteSpace(objReq.EmpName))
                {
                    objResp.vErrorMsg = "Please Employee Name";
                }
                else if (String.IsNullOrWhiteSpace(objReq.EmpEmailId))
                {
                    objResp.vErrorMsg = "Please EmailId";
                }
                else if (String.IsNullOrWhiteSpace(objReq.EmpMobile))
                {
                    objResp.vErrorMsg = "Please Mobile";
                }
                else if (objReq.EmpGrade != null || objReq.EmpGrade != 0)
                {
                    objResp.vErrorMsg = "Please Select Grade";
                }
                else if (objReq.EmpLocation != null || objReq.EmpLocation != "0")
                {
                    objResp.vErrorMsg = "Please Select Location";
                }
                else if (String.IsNullOrWhiteSpace(objReq.EmpPassword))
                {
                    objResp.vErrorMsg = "Please Password";
                }
                else
                {
                    if (Con.State == ConnectionState.Broken)
                    {
                        Con.Close();
                    }
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    cmd = new SqlCommand("USP_Employee", Con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", objReq.EmpId);
                    cmd.Parameters.AddWithValue("@EmpName", objReq.EmpName);
                    cmd.Parameters.AddWithValue("@EmpEmailId", objReq.EmpEmailId);
                    cmd.Parameters.AddWithValue("@EmpMobile", objReq.EmpMobile);
                    cmd.Parameters.AddWithValue("@EmpGrade", objReq.EmpGrade);
                    cmd.Parameters.AddWithValue("@EmpLocation", objReq.EmpLocation);
                    cmd.Parameters.AddWithValue("@BSLTravelDesk", objReq.BSLTravelDesk);
                    cmd.Parameters.AddWithValue("@EmpPassword", objReq.EmpPassword);
                    cmd.Parameters.AddWithValue("@DOB", objReq.DOB);
                    cmd.Parameters.AddWithValue("@QueryType", "Insert");
                    int i = 0;
                    i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        objResp.vErrorMsg = "Success";
                    }
                    else
                    {
                        objResp.vErrorMsg = "Faild";
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteLog("Function Name : Fn_Add_Employee", " " + "Error Msg : " + exp.Message.ToString(), new StackTrace(exp, true));
                objResp.vErrorMsg = exp.Message.ToString();
            }
            finally
            {
                Con.Close();
                cmd.Dispose();
            }
            return objResp;
        }

        public clsEmployee Fn_Update_Employee(clsEmployee objReq)
        {
            var objResp = new clsEmployee();
            try
            {
                if (objReq.EmpId != null || objReq.EmpId != 0)
                {
                    objResp.vErrorMsg = "Please Enter User Id.";
                }
                else if (String.IsNullOrWhiteSpace(objReq.EmpName))
                {
                    objResp.vErrorMsg = "Please Employee Name";
                }
                else if (String.IsNullOrWhiteSpace(objReq.EmpEmailId))
                {
                    objResp.vErrorMsg = "Please EmailId";
                }
                else if (String.IsNullOrWhiteSpace(objReq.EmpMobile))
                {
                    objResp.vErrorMsg = "Please Mobile";
                }
                else if (objReq.EmpGrade != null || objReq.EmpGrade != 0)
                {
                    objResp.vErrorMsg = "Please Select Grade";
                }
                else if (objReq.EmpLocation != null || objReq.EmpLocation != "0")
                {
                    objResp.vErrorMsg = "Please Select Location";
                }
                else if (String.IsNullOrWhiteSpace(objReq.EmpPassword))
                {
                    objResp.vErrorMsg = "Please Password";
                }
                else
                {
                    if (Con.State == ConnectionState.Broken)
                    {
                        Con.Close();
                    }
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    cmd = new SqlCommand("USP_Employee", Con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", objReq.EmpId);
                    cmd.Parameters.AddWithValue("@EmpName", objReq.EmpName);
                    cmd.Parameters.AddWithValue("@EmpLastName", objReq.EmpLastName);
                    cmd.Parameters.AddWithValue("@EmpEmailId", objReq.EmpEmailId);
                    cmd.Parameters.AddWithValue("@EmpMobile", objReq.EmpMobile);
                    cmd.Parameters.AddWithValue("@EmpGrade", objReq.EmpGrade);
                    cmd.Parameters.AddWithValue("@EmpLocation", objReq.EmpLocation);
                    cmd.Parameters.AddWithValue("@BSLTravelDesk", objReq.BSLTravelDesk);
                    cmd.Parameters.AddWithValue("@EmpPassword", objReq.EmpPassword);
                    cmd.Parameters.AddWithValue("@DOB", objReq.DOB);
                    cmd.Parameters.AddWithValue("@QueryType", "Update");
                    int i = 0;
                    i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        objResp.vErrorMsg = "Success";
                    }
                    else
                    {
                        objResp.vErrorMsg = "Faild";
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteLog("Function Name : Fn_Update_Employee", " " + "Error Msg : " + exp.Message.ToString(), new StackTrace(exp, true));
                objResp.vErrorMsg = exp.Message.ToString();
            }
            finally
            {
                Con.Close();
            }

            return objResp;
        }

        public clsEmployee Fn_Delete_Employee(clsEmployee objReq)
        {
            var objResp = new clsEmployee();
            try
            {
                if (objReq.EmpId != null || objReq.EmpId != 0)
                {
                    objResp.vErrorMsg = "Please Enter User Id.";
                }
                else
                {
                    if (Con.State == ConnectionState.Broken)
                    {
                        Con.Close();
                    }
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    cmd = new SqlCommand("USP_Employee", Con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", objReq.EmpId);
                    cmd.Parameters.AddWithValue("@QueryType", "Delete");
                    int i = 0;
                    i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        objResp.vErrorMsg = "Success";
                    }
                    else
                    {
                        objResp.vErrorMsg = "Faild";
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteLog("Function Name : Fn_Delete_Employee", " " + "Error Msg : " + exp.Message.ToString(), new StackTrace(exp, true));
                objResp.vErrorMsg = exp.Message.ToString();
            }
            finally
            {
                Con.Close();
            }

            return objResp;
        }

        public clsEmployee Fn_LogIn_Employee(clsEmployee objReq)
        {
            var objResp = new clsEmployee();
            try
            {
                if (objReq.EmpId != null || objReq.EmpId != 0)
                {
                    objResp.vErrorMsg = "Please Enter User Id.";
                }
                else if (String.IsNullOrWhiteSpace(objReq.EmpPassword))
                {
                    objResp.vErrorMsg = "Please Password";
                }
                else
                {
                    if (Con.State == ConnectionState.Broken)
                    {
                        Con.Close();
                    }
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    cmd = new SqlCommand("USP_Employee", Con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", objReq.EmpId);
                    cmd.Parameters.AddWithValue("@EmpPassword", objReq.EmpPassword);
                    cmd.Parameters.AddWithValue("@QueryType", "LogIn");
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        objResp.EmpId = Convert.ToInt32(dr["EmpId"]);
                        objResp.EmpName = Convert.ToString(dr["EmpName"]);
                        objResp.EmpEmailId = Convert.ToString(dr["EmpEmailId"]);
                        objResp.EmpMobile = Convert.ToString(dr["EmpMobile"]);
                        objResp.EmpLocation = Convert.ToString(dr["EmpLocation"]);
                        objResp.EmpId = Convert.ToInt32(dr["EmpId"]);
                        objResp.vErrorMsg = "Success";
                    }
                    else
                    {
                        objResp.vErrorMsg = "Faild";
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteLog("Function Name : Fn_LogIn_Employee", " " + "Error Msg : " + exp.Message.ToString(), new StackTrace(exp, true));
                objResp.vErrorMsg = exp.Message.ToString();
            }
            finally
            {
                dr.Close();
                cmd.Dispose();
                Con.Close();
            }

            return objResp;
        }

        public List<clsEmployee> Fn_Get_All_Employee(clsEmployee objReq)
        {
            var objRespList = new List<clsEmployee>();
            var objResp = new clsEmployee();
            try
            {
                if (Con.State == ConnectionState.Broken)
                {
                    Con.Close();
                }
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }

                cmd = new SqlCommand("USP_Employee", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@QueryType", "SelectAll");
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                int i = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    while (ds.Tables[0].Rows.Count > i)
                    {
                        objResp = new clsEmployee();

                        objResp.EmpId = Convert.ToInt32(ds.Tables[0].Rows[i]["EmpId"]);
                        objResp.EmpName = Convert.ToString(ds.Tables[0].Rows[i]["EmpName"]);
                        objResp.EmpEmailId = Convert.ToString(ds.Tables[0].Rows[i]["EmpEmailId"]);
                        objResp.EmpMobile = Convert.ToString(ds.Tables[0].Rows[i]["EmpMobile"]);
                        objResp.EmpGrade = Convert.ToInt32(ds.Tables[0].Rows[i]["EmpGrade"]);
                        objResp.EmpLocation = Convert.ToString(ds.Tables[0].Rows[i]["EmpLocation"]);

                        objResp.BSLTravelDesk = Convert.ToInt32(ds.Tables[0].Rows[i]["BSLTravelDesk"]);
                        objResp.EmpPassword = Convert.ToString(ds.Tables[0].Rows[i]["EmpPassword"]);
                        objResp.DOB = Convert.ToDateTime(ds.Tables[0].Rows[i]["DOB"]);
                        objResp.vErrorMsg = "Success";
                        objRespList.Add(objResp);
                        i++;
                    }
                }
                else
                {
                    objResp.vErrorMsg = "No record found.";
                    objRespList.Add(objResp);
                }
            }
            catch (Exception exp)
            {
                Logger.WriteLog("Function Name : Fn_Get_All_Employee", " " + "Error Msg : " + exp.Message.ToString(), new StackTrace(exp, true));
                objResp.vErrorMsg = exp.Message.ToString();
                objRespList.Add(objResp);
            }
            finally
            {
                cmd.Dispose();
                Con.Close();
            }

            return objRespList;
        }

        public clsEmployee Fn_Get_EmployeeByID(clsEmployee objReq)
        {
            var objResp = new clsEmployee();
            try
            {
                if (Con.State == ConnectionState.Broken)
                {
                    Con.Close();
                }
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }
                cmd = new SqlCommand("USP_Employee", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId", objReq.EmpId);
                cmd.Parameters.AddWithValue("@QueryType", "SelectByID");
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                int i = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    while (ds.Tables[0].Rows.Count > i)
                    {

                        objResp.EmpId = Convert.ToInt32(ds.Tables[0].Rows[i]["EmpId"]);
                        objResp.EmpName = Convert.ToString(ds.Tables[0].Rows[i]["EmpName"]);
                        objResp.EmpEmailId = Convert.ToString(ds.Tables[0].Rows[i]["EmpEmailId"]);
                        objResp.EmpMobile = Convert.ToString(ds.Tables[0].Rows[i]["EmpMobile"]);
                        objResp.EmpGrade = Convert.ToInt32(ds.Tables[0].Rows[i]["EmpGrade"]);
                        objResp.EmpLocation = Convert.ToString(ds.Tables[0].Rows[i]["EmpLocation"]);

                        objResp.BSLTravelDesk = Convert.ToInt32(ds.Tables[0].Rows[i]["BSLTravelDesk"]);
                        objResp.EmpPassword = Convert.ToString(ds.Tables[0].Rows[i]["EmpPassword"]);
                        objResp.DOB = Convert.ToDateTime(ds.Tables[0].Rows[i]["DOB"]);
                        objResp.vErrorMsg = "Success";
                    }
                }
                else
                {
                    objResp.vErrorMsg = "No record found.";
                }
            }
            catch (Exception exp)
            {
                Logger.WriteLog("Function Name : Fn_Get_EmployeeByID", " " + "Error Msg : " + exp.Message.ToString(), new StackTrace(exp, true));
                objResp.vErrorMsg = exp.Message.ToString();
            }
            finally
            {
                cmd.Dispose();
                Con.Close();
            }

            return objResp;
        }
    }
}