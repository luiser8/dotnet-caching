using System.Collections;
using System.Data;
using dotnetcaching.Entities;
using dotnetcaching.Utils;

namespace dotnetcaching.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly CustomDataTable dbCon;
        private DataTable? dt;
        private readonly Hashtable Params;

        public UsersRepository()
        {
            dt = new DataTable();
            dbCon = new CustomDataTable();
            Params = new Hashtable();
        }

        public async Task<List<UsersRolPolicy>> SelectPolicyUsersAllRepository()
        {
            Params.Clear();
            List<UsersRolPolicy> usersList = new();
            dt = await dbCon.ExecuteAsync("SP_Users_Select_All", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        usersList.Add(new UsersRolPolicy
                        {
                            dataUser = new DataUser{
                                idUser = Convert.ToInt32(dt.Rows[i]["idUser"]),
                                firstName = Convert.ToString(dt.Rows[i]["firstName"]),
                                lastName = Convert.ToString(dt.Rows[i]["lastName"]),
                                email = Convert.ToString(dt.Rows[i]["email"]),
                                statusUser = Convert.ToBoolean(dt.Rows[i]["statusUser"])
                            },
                            dataUserRol = new DataUserRol{
                                idRol = Convert.ToInt32(dt.Rows[i]["idRol"]),
                                codeRol = Convert.ToString(dt.Rows[i]["codeRol"]),
                                descriptionRol = Convert.ToString(dt.Rows[i]["descriptionRol"]),
                                statusRol = Convert.ToBoolean(dt.Rows[i]["statusRol"])
                            },
                            policyUser = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PolicyUser>>(Convert.ToString(dt.Rows[i]["policyUser"]))
                        });
                    }
                }
            }
            return usersList;
        }

        public async Task<UsersRolPolicy> SelectPolicyUserByIdRepository(int IdUser)
        {
            Params.Clear();
            Params.Add("@idUser", IdUser);
            UsersRolPolicy usersList = new();
            dt = await dbCon.ExecuteAsync("SP_Users_Select_ById", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        usersList = new UsersRolPolicy
                        {
                            dataUser = new DataUser{
                                idUser = Convert.ToInt32(dt.Rows[i]["idUser"]),
                                firstName = Convert.ToString(dt.Rows[i]["firstName"]),
                                lastName = Convert.ToString(dt.Rows[i]["lastName"]),
                                email = Convert.ToString(dt.Rows[i]["email"]),
                                statusUser = Convert.ToBoolean(dt.Rows[i]["statusUser"])
                            },
                            dataUserRol = new DataUserRol{
                                idRol = Convert.ToInt32(dt.Rows[i]["idRol"]),
                                codeRol = Convert.ToString(dt.Rows[i]["codeRol"]),
                                descriptionRol = Convert.ToString(dt.Rows[i]["descriptionRol"]),
                                statusRol = Convert.ToBoolean(dt.Rows[i]["statusRol"])
                            },
                            policyUser = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PolicyUser>>(Convert.ToString(dt.Rows[i]["policyUser"]))
                        };
                    }
                }
            }
            return usersList;
        }

        public async Task<int> InsertUserRepository(UserDto userDto)
        {
            int idUser = 0;
            Params.Clear();
            Params.Add("@firstName", userDto.firstName);
            Params.Add("@lastName", userDto.lastName);
            Params.Add("@email", userDto.email);
            Params.Add("@password", userDto.password);
            Params.Add("@idRol", userDto.idRol);

            dt = await dbCon.ExecuteAsync("SP_Users_Insert", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        idUser = Convert.ToInt16(dt.Rows[i]["idUser"]);
                    }
                }
            }
            return idUser;
        }
    }
}