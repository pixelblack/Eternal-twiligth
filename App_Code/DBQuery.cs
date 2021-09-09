using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Compilation;
using System.IO;
using System.Web.Configuration;

public class DBQuerys
{
    public enum PostType : byte
    {
        News, Images, Audio
    }
    public static String DataBase = "DataBase";
    public static Boolean ValidateLogin(String user, String password)
    {
        using(SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings[DataBase].ConnectionString))
        {
            con.Open();
            using(SqlCommand cmd = new SqlCommand("sp_ValidateLogin", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@user", user));
                cmd.Parameters.Add(new SqlParameter("@pass", password));
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                try
                {
                    if((dt.Rows[0]["userName"].ToString() == user) && (dt.Rows[0]["password"].ToString() == password))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch(Exception) { return false; };

            }
        }

    } //ya
    public static Boolean UserRegistry(String realName, String userName, String password, String email, Char gender)
    {
        using(SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings[DataBase].ConnectionString))
        {
            con.Open();
            using(SqlCommand cmd = new SqlCommand("sp_RegisterUser", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@realName", realName));
                    cmd.Parameters.Add(new SqlParameter("@userName", userName));
                    cmd.Parameters.Add(new SqlParameter("@password", password));
                    cmd.Parameters.Add(new SqlParameter("@email", email));
                    cmd.Parameters.Add(new SqlParameter("@gender", gender));
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch(Exception) { return false; }
            }
        }
    } //ya
    public static Boolean UserExists(String userName)
    {
        using(SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings[DataBase].ConnectionString))
        {
            con.Open();
            using(SqlCommand cmd = new SqlCommand("sp_UserExists", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@user", userName));
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                try
                {
                    if((dt.Rows[0]["userName"].ToString() == userName))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch(Exception) { return false; }

            }

        }
    }  // ya
    public static Boolean ModifyPassword(String email, String password)
    {
        using(SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings[DataBase].ConnectionString))
        {
            con.Open();
            using(SqlCommand cmd = new SqlCommand("sp_ModifyPassword", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@email", email));
                cmd.Parameters.Add(new SqlParameter("@newPass", password));
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch(Exception) { return false; }
            }
        }
    } //ya
    public static String GetPassByEmail(String email)
    {
        using(SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings[DataBase].ConnectionString))
        {
            con.Open();
            using(SqlCommand cmd = new SqlCommand("sp_GetPassByEmail", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@email", email));
                DataTable dt = new DataTable();
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt.Rows[0]["password"].ToString();
                }
                catch(Exception) { return "ERROR"; }
            }
        }
    } //ya
    public static Boolean UploadPost(String title, String textContent, String fecha, Byte[] image, String category, Byte[] audio = null)
    {
        using(SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings[DataBase].ConnectionString))
        {
            con.Open();
            using(SqlCommand cmd = new SqlCommand("sp_UploadPost", con))
            {
                try
                {
                    if(audio == null)
                    {
                        audio = new Byte[0];
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@title", title));
                    cmd.Parameters.Add(new SqlParameter("@textContent", textContent));
                    cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
                    SqlParameter imageparam = cmd.Parameters.Add("@image", SqlDbType.VarBinary);
                    imageparam.Value = image;
                    SqlParameter audioparam = cmd.Parameters.Add("@audio", SqlDbType.VarBinary);
                    audioparam.Value = audio;
                    cmd.Parameters.Add(new SqlParameter("@category", category));
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch(Exception) { return false; }
            }
        }
    } //ya
    public static Boolean DeletePost(String title)
    {
        using(SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings[DataBase].ConnectionString))
        {
            con.Open();
            using(SqlCommand cmd = new SqlCommand("sp_DeletePost", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@title", title));
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch(Exception) { return false; }
            }
        };
    }
    public static Boolean DeletePostByID(String ID)
    {
        using(SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings[DataBase].ConnectionString))
        {
            con.Open();
            using(SqlCommand cmd = new SqlCommand("sp_DeletePostByID", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", ID));
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch(Exception) { return false; }
            }
        };
    }
    public static DataTable GetPosts(PostType type)
    {
        switch(type)
        {
            case PostType.News:
                using(SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings[DataBase].ConnectionString))
                {
                    con.Open();
                    using(SqlCommand cmd = new SqlCommand("sp_GetNews", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        try
                        {
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dt);
                            return dt;
                        }
                        catch(Exception) { return dt; }
                    }
                }
            case PostType.Images:
                using(SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings[DataBase].ConnectionString))
                {
                    con.Open();
                    using(SqlCommand cmd = new SqlCommand("sp_GetImages", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        try
                        {
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dt);
                            return dt;
                        }
                        catch(Exception) { return dt; }
                    }
                }
            case PostType.Audio:
                using(SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings[DataBase].ConnectionString))
                {
                    con.Open();
                    using(SqlCommand cmd = new SqlCommand("sp_GetAudio", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        try
                        {
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dt);
                            return dt;
                        }
                        catch(Exception) { return dt; }
                    }
                }
            default:
                break;
        }
        using(SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings[DataBase].ConnectionString))
        {
            con.Open();
            using(SqlCommand cmd = new SqlCommand("sp_GetAudio", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
                catch(Exception) { return dt; }
            }
        }

    }
    public static Byte[] GetImgById(Int32 id)
    {
        
        using(SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings[DataBase].ConnectionString))
        {
            con.Open();
            using(SqlCommand cmd = new SqlCommand("sp_ImageById", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id));
                DataTable dt = new DataTable();               
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    
                    da.Fill(dt);
                    Byte[] bytes = (Byte[])dt.Rows[0]["image"];
                    return bytes;                   
                }
                catch(Exception) {Byte[] bytes = new Byte[0];return bytes; }
            }
        }
    }
    public static Byte[] GetAudioById(Int32 id)
    {

        using(SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings[DataBase].ConnectionString))
        {
            con.Open();
            using(SqlCommand cmd = new SqlCommand("sp_GetAudioById", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id));
                DataTable dt = new DataTable();
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(dt);
                    Byte[] bytes = (Byte[])dt.Rows[0]["audio"];                   
                    return bytes;
                }
                catch(Exception) { Byte[] bytes = new Byte[0]; return bytes; }
            }
        }
    }
}