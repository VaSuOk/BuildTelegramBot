using BuildTelegramBot.Models;
using BuildTelegramBot.User;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BuildTelegramBot.MySQL
{
    public static class SqlQuery
    {
        public static bool LoginByPhone(string Phone, string ChatID)
        {
            DataTable temp = new DataTable();
            try
            {
                DataBase.Get_Instance().Connect();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT `ID`, `ChatID` FROM `user` WHERE `Phone` = '" + Phone+"' ", DataBase.Get_Instance().connection);
                adapter.SelectCommand = command;
                adapter.Fill(temp);
                if (temp.Rows.Count > 0)
                {
                    ListUsers.Get_instance().SetID(ChatID, Convert.ToInt32(temp.Rows[0][0]));
                    string chatID = temp.Rows[0][1].ToString();
                    if (chatID != ChatID)
                    {
                        command = new MySqlCommand("UPDATE `user` SET `ChatID` = '" + ChatID + "' WHERE `Phone` = '" + Phone + "' ", DataBase.Get_Instance().connection);
                        command.ExecuteNonQuery();
                    }
                    DataBase.Get_Instance().Disconnect();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string tmp = ex.Message;
                DataBase.Get_Instance().Disconnect();
                return false;
            }
        }
        public static bool LoginByLogAndPass(string Login, string Password, string ChatID)
        {
            DataTable temp = new DataTable();
            try
            {
                DataBase.Get_Instance().Connect();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT `ID`, `ChatID` FROM `user` WHERE `Login` = '" + Login + "' AND `Password` = `"+Password+"` ", DataBase.Get_Instance().connection);
                adapter.SelectCommand = command;
                adapter.Fill(temp);
                if (temp.Rows.Count > 0)
                {
                    ListUsers.Get_instance().SetID(ChatID, Convert.ToInt32(temp.Rows[0][0]));
                    string chatID = temp.Rows[0][1].ToString();
                    if(chatID != ChatID)
                    {
                        command = new MySqlCommand("UPDATE `user` SET `ChatID` = '"+ChatID+"' WHERE `Login` = '" + Login + "' AND `Password` = `" + Password + "` ", DataBase.Get_Instance().connection);
                        command.ExecuteNonQuery();
                    }
                    DataBase.Get_Instance().Disconnect();
                    return true;
                }
                else
                {
                    DataBase.Get_Instance().Disconnect();
                    return false;
                }
            }
            catch (Exception ex)
            {
                string tmp = ex.Message;
                DataBase.Get_Instance().Disconnect();
                return false;
            }
        }

        public static bool ChangeLogAndPass(string Login, string Password, string ChatID)
        {
            DataTable temp = new DataTable();
            try
            {
                DataBase.Get_Instance().Connect();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("UPDATE `user` SET `Login` = @Login, `Password` = @Password WHERE `ChatID` = @ChatID ", DataBase.Get_Instance().connection);
                command.Parameters.Add("@Login", MySqlDbType.VarChar).Value = Login;
                command.Parameters.Add("@Password", MySqlDbType.VarChar).Value = Password;
                command.Parameters.Add("@ChatID", MySqlDbType.VarChar).Value = ChatID;
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string tmp = ex.Message;
                DataBase.Get_Instance().Disconnect();
                return false;
            }
        }
        public static Brigade GetBrigade(int ID)
        {
            try
            {
                DataTable temp = new DataTable();

                DataBase.Get_Instance().Connect();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT `ID` FROM `user_working_information` WHERE `ID_User` = @ID_User ", DataBase.Get_Instance().connection);
                command.Parameters.Add("@ID_User", MySqlDbType.Int32).Value = ID;

                adapter.SelectCommand = command;
                adapter.Fill(temp);
                if (temp.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(temp.Rows[0][0]);
                    command = new MySqlCommand("SELECT * FROM `brigade` WHERE `user1` = '"+ id + "' OR `user2` = '" + id + "' OR `user3` = '" + id + "' OR `user4` = '" + id + "' OR `user5` = '" + id + "' OR `user6` = '" + id + "' OR `user7` = '" + id + "' OR `user8` = '" + id + "' ", DataBase.Get_Instance().connection);
                    adapter.SelectCommand = command;
                    temp.Clear();
                    adapter.Fill(temp);
                    if (temp.Rows.Count > 0)
                    {
                        Brigade brigade = new Brigade();
                        brigade.ID = Convert.ToInt32(temp.Rows[0][0]);
                        brigade.Name = Convert.ToString(temp.Rows[0][1]);
                        brigade.WorkRegion = Convert.ToString(temp.Rows[0][2]);
                        brigade.WorkStage = Convert.ToString(temp.Rows[0][3]);
                        brigade.Amount = Convert.ToInt32(temp.Rows[0][4]);

                        brigade.ID_user1 = Convert.ToInt32(temp.Rows[0][5]);
                        brigade.ID_user2 = Convert.ToInt32(temp.Rows[0][6]);
                        brigade.ID_user3 = Convert.ToInt32(temp.Rows[0][7]);
                        brigade.ID_user4 = Convert.ToInt32(temp.Rows[0][8]);
                        brigade.ID_user5 = Convert.ToInt32(temp.Rows[0][9]);
                        brigade.ID_user6 = Convert.ToInt32(temp.Rows[0][10]);
                        brigade.ID_user7 = Convert.ToInt32(temp.Rows[0][11]);
                        brigade.ID_user8 = Convert.ToInt32(temp.Rows[0][12]);
                        brigade.TaskID = Convert.ToInt32(temp.Rows[0][13]);
                        return brigade;
                    }
                        DataBase.Get_Instance().Disconnect();
                    return null;
                }
                else
                {
                    DataBase.Get_Instance().Disconnect();
                    return null;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static TaskArchitect GetTaskByIDWorker(int id)
        {
            DataTable temp = new DataTable();
            try
            {
                DataBase.Get_Instance().Connect();
                MySqlCommand command = new MySqlCommand(
                            "SELECT * FROM `architecttask` WHERE `ID_User` = @ID", DataBase.Get_Instance().connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
                adapter.SelectCommand = command;
                adapter.Fill(temp);
                if (temp.Rows.Count > 0)
                {
                    TaskArchitect taskArchitect = new TaskArchitect();
                    taskArchitect.ID = Convert.ToInt32(temp.Rows[0][0]);
                    taskArchitect.Architect = GetUserWIByID(Convert.ToInt32(temp.Rows[0][1]));
                    taskArchitect.constructionObject = GetBObjectByID(Convert.ToInt32(temp.Rows[0][2]));
                    taskArchitect.DateCreation = Convert.ToString(temp.Rows[0][3]);
                    taskArchitect.DateEnd = Convert.ToString(temp.Rows[0][4]);
                    taskArchitect.Status = Convert.ToString(temp.Rows[0][5]);
                    taskArchitect.BuildPlan = (byte[])temp.Rows[0][6];
                    return taskArchitect;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string ar = ex.Message;
                throw;
            }
        }

        public static ConstructionObject GetBObjectByID(int id)
        {
            DataTable temp = new DataTable();
            try
            {
                DataBase.Get_Instance().Connect();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `constructionobject`  WHERE `ID` = @ID", DataBase.Get_Instance().connection);
                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
                adapter.SelectCommand = command;
                adapter.Fill(temp);
                if (temp.Rows.Count > 0)
                {
                    ConstructionObject constructionObject = new ConstructionObject();
                    constructionObject.ID = Convert.ToInt32(temp.Rows[0][0]);
                    constructionObject.customer = GetCustomerByID(Convert.ToInt32(temp.Rows[0][1]));
                    constructionObject.Region = Convert.ToString(temp.Rows[0][2]);
                    constructionObject.Sity = Convert.ToString(temp.Rows[0][3]);
                    constructionObject.Street = Convert.ToString(temp.Rows[0][4]);
                    constructionObject.TypeBuilding = Convert.ToString(temp.Rows[0][5]);
                    constructionObject.TypeRoof = Convert.ToString(temp.Rows[0][6]);
                    constructionObject.RoofMaterial = Convert.ToString(temp.Rows[0][7]);
                    constructionObject.WallMaterial = Convert.ToString(temp.Rows[0][8]);
                    constructionObject.DataCreate = Convert.ToString(temp.Rows[0][9]);
                    constructionObject.Image = (byte[])(temp.Rows[0][10]);
                    constructionObject.Stage = Convert.ToInt32(temp.Rows[0][11]);

                    DataBase.Get_Instance().Disconnect();

                    return constructionObject;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string tmp = ex.Message;
                DataBase.Get_Instance().Disconnect();
                return null;
            }
        }
        public static Customer GetCustomerByID(int ID)
        {
            DataTable temp = new DataTable();
            try
            {
                DataBase.Get_Instance().Connect();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `customer` WHERE `ID` = @ID ", DataBase.Get_Instance().connection);
                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = ID;
                adapter.SelectCommand = command;
                adapter.Fill(temp);
                DataBase.Get_Instance().Disconnect();
                if (temp.Rows.Count > 0)
                {
                    Customer customer = new Customer();
                    customer.ID = Convert.ToInt32(temp.Rows[0][0]);
                    customer.PIB = Convert.ToString(temp.Rows[0][1]);
                    customer.Phone = Convert.ToString(temp.Rows[0][2]);
                    customer.Email = Convert.ToString(temp.Rows[0][3]);
                    return customer;
                }

                else
                {
                    DataBase.Get_Instance().Disconnect();
                    return null;
                }

            }
            catch
            {
                DataBase.Get_Instance().Disconnect();
                return null;
            }
        }
        public static List<UserWorkInformation> GetUsers(Brigade brigade)
        {
            List<UserWorkInformation> userWorkInformation = new List<UserWorkInformation>();
            if(brigade != null)
            {
                for(int i = 0; i<brigade.Amount; i++)
                {
                    UserWorkInformation userW = new UserWorkInformation();
                    switch (i)
                    {
                        case 0:
                            {
                                userW = GetUserWIByID(brigade.ID_user1);
                                break;
                            }
                        case 1:
                            {
                                userW = GetUserWIByID(brigade.ID_user2);
                                break;
                            }
                        case 2:
                            {
                                userW = GetUserWIByID(brigade.ID_user3);
                                break;
                            }
                        case 3:
                            {
                                userW = GetUserWIByID(brigade.ID_user4);
                                break;
                            }
                        case 4:
                            {
                                userW = GetUserWIByID(brigade.ID_user5);
                                break;
                            }
                        case 5:
                            {
                                userW = GetUserWIByID(brigade.ID_user6);
                                break;
                            }
                        case 6:
                            {
                                userW = GetUserWIByID(brigade.ID_user7);
                                break;
                            }
                        case 7:
                            {
                                userW = GetUserWIByID(brigade.ID_user8);
                                break;
                            }

                    }
                    userWorkInformation.Add(userW);
                }
                return userWorkInformation;
            }
            return null;
        }

        public static UserWorkInformation GetUserWIByIDUser(int ID)
        {
            DataTable temp = new DataTable();
            try
            {
                DataBase.Get_Instance().Connect();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `user_working_information` WHERE `ID_User` = @ID", DataBase.Get_Instance().connection);
                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = ID;
                adapter.SelectCommand = command;
                adapter.Fill(temp);
                if (temp.Rows.Count > 0)
                {

                    UserWorkInformation userWorkInformation = new UserWorkInformation();
                    userWorkInformation.ID = Convert.ToUInt32(temp.Rows[0][0]);
                    userWorkInformation.user = GetUserByID(Convert.ToInt32(temp.Rows[0][1]));
                    userWorkInformation.Stage = (temp.Rows[0][2]).ToString();
                    userWorkInformation.Position = (temp.Rows[0][3]).ToString();
                    userWorkInformation.WorkRegion = (temp.Rows[0][4]).ToString();
                    userWorkInformation.Salary = (temp.Rows[0][5]).ToString();

                    DataBase.Get_Instance().Disconnect();

                    return userWorkInformation;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string tmp = ex.Message;
                DataBase.Get_Instance().Disconnect();
                return null;
            }
        }
        public static UserWorkInformation GetUserWIByID(int ID)
        {
            DataTable temp = new DataTable();
            try
            {
                DataBase.Get_Instance().Connect();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `user_working_information` WHERE `ID` = @ID", DataBase.Get_Instance().connection);
                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = ID;
                adapter.SelectCommand = command;
                adapter.Fill(temp);
                if (temp.Rows.Count > 0)
                {

                    UserWorkInformation userWorkInformation = new UserWorkInformation();
                    userWorkInformation.ID = Convert.ToUInt32(temp.Rows[0][0]);
                    userWorkInformation.user = GetUserByID(Convert.ToInt32(temp.Rows[0][1]));
                    userWorkInformation.Stage = (temp.Rows[0][2]).ToString();
                    userWorkInformation.Position = (temp.Rows[0][3]).ToString();
                    userWorkInformation.WorkRegion = (temp.Rows[0][4]).ToString();
                    userWorkInformation.Salary = (temp.Rows[0][5]).ToString();

                    DataBase.Get_Instance().Disconnect();

                    return userWorkInformation;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string tmp = ex.Message;
                DataBase.Get_Instance().Disconnect();
                return null;
            }
        }
        public static Models.User GetUserByID(int ID)
        {
            DataTable temp = new DataTable();
            try
            {
                DataBase.Get_Instance().Connect();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `ID` = @ID", DataBase.Get_Instance().connection);
                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = ID;
                adapter.SelectCommand = command;
                adapter.Fill(temp);
                if (temp.Rows.Count > 0)
                {
                    adapter.Fill(temp);

                    Models.User user = new Models.User(); user.id = Convert.ToUInt32(temp.Rows[0][0]);
                    user.id = Convert.ToUInt32(temp.Rows[0][0]);
                    user.Name = Convert.ToString(temp.Rows[0][1]);
                    user.Surname = Convert.ToString(temp.Rows[0][2]); user.Email = Convert.ToString(temp.Rows[0][3]);
                    user.Phone = Convert.ToString(temp.Rows[0][4]); user.Region = Convert.ToString(temp.Rows[0][5]);
                    user.Sity = Convert.ToString(temp.Rows[0][6]); user.UserImage = (byte[])(temp.Rows[0][7]);
                    user.Birthday = Convert.ToString(temp.Rows[0][8]);

                    DataBase.Get_Instance().Disconnect();

                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                DataBase.Get_Instance().Disconnect();
                return null;
            }
        }

    }
}
