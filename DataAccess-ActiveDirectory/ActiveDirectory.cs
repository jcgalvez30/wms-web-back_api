using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace DataAccess_ActiveDirectory;
    public class ActiveDirectory {
        public string vgLogRoot { get; set; }
        public string vgDomain { get; set; }
        public string vgUnidadOrg { get; set; }
        public string vgUserAdmin { get; set; }
        public string vgPassAdmin { get; set; }
        public ActiveDirectory( string pRoot, string pDomain, string pOu, string pUserAdmin, string pPassAdmin ) {
            vgLogRoot = pRoot;
            vgDomain = pDomain;
            vgUnidadOrg = pOu;
            vgUserAdmin = pUserAdmin;
            vgPassAdmin = pPassAdmin;
        }
        public DataSet validarCuentaUsuario( string pUser ) {
            DataSet oDs = new DataSet();
            try {
                DirectoryEntry oDeActiveDirectory = null;
                if (vgPassAdmin.Equals(""))
                    oDeActiveDirectory = new DirectoryEntry(@"LDAP://" + vgLogRoot + vgUnidadOrg);
                else
                    oDeActiveDirectory = new DirectoryEntry(@"LDAP://" + vgLogRoot + vgUnidadOrg, vgDomain + @"\" + vgUserAdmin, vgPassAdmin, AuthenticationTypes.None);
                DirectoryEntry oDeUser = oDeActiveDirectory.Children.Find("CN=" + pUser, "User");
                oDs = ObjectUtils.generarDsMensaje("200", "RS", "El usuario esxiste en el servidor");
            } catch (DirectoryServicesCOMException ex) {
                Console.WriteLine("{0} Exception caught.", ex);
                oDs = ObjectUtils.generarDsMensaje("0", "ER", "El usuario no esxiste en el servidor");
            }
            return oDs;
        }
        public DataSet crearUsuario( string pUsuario, string pPassword, string vNombres, string vApellidos, string pNumDoc, string pEntidad, string pCargo, bool pFlagEnabled, DateTime pFechaExpiracion ) {
            DataSet oDs = new DataSet();
            try {
                DirectoryEntry oDeActiveDirectory = new DirectoryEntry(@"LDAP://" + vgLogRoot + vgUnidadOrg, vgDomain + @"\" + vgUserAdmin, vgPassAdmin, AuthenticationTypes.None);
                DirectoryEntry oDeNewUser = oDeActiveDirectory.Children.Add("CN=" + pUsuario, "User");
                oDeNewUser.Properties["sAMAccountName"].Value = pUsuario;
                oDeNewUser.CommitChanges();
                oDeNewUser.Invoke("SetPassword", new object[] { pPassword });
                oDeNewUser.Invoke("Put", new object[] { "SN", vApellidos });//LastName
                oDeNewUser.Invoke("Put", new object[] { "GivenName", vNombres });//Nombre
                oDeNewUser.Invoke("Put", new object[] { "Description", "DNI : " + pNumDoc + "; Cargo : " + pCargo + " ; Entidad : " + pEntidad });
                oDeNewUser.CommitChanges();
                oDeNewUser.InvokeSet("AccountExpirationDate", new object[] { pFechaExpiracion });
                oDeNewUser.CommitChanges();
                // pass never expires
                int vFlagExpire = 0x10000;
                int vValue = (int)oDeNewUser.Properties["userAccountControl"].Value;
                oDeNewUser.Properties["userAccountControl"].Value = vValue | vFlagExpire;
                oDeNewUser.CommitChanges();
                //cuenta habilitada/deshabilitada
                int vOldUAC = (int)oDeNewUser.Properties["userAccountControl"][0];
                int vFlagCuentaDeshabilitada = 2;
                if (pFlagEnabled)
                    oDeNewUser.Properties["userAccountControl"][0] = (vOldUAC & ~vFlagCuentaDeshabilitada);
                else
                    oDeNewUser.Properties["userAccountControl"][0] = (vOldUAC | vFlagCuentaDeshabilitada);
                oDeNewUser.CommitChanges();
                oDeActiveDirectory.Close();
                oDeNewUser.Close();
                oDs = ObjectUtils.generarDsOk();
            } catch (DirectoryServicesCOMException ex) {
                oDs = ObjectUtils.generarDsMensaje("0", "ER", ex.ExtendedErrorMessage);
            } catch (System.Reflection.TargetInvocationException ex) {
                oDs = ObjectUtils.generarDsMensaje("0", "ER", ex.Message);
            } catch (Exception ex) {
                oDs = ObjectUtils.generarDsMensaje("0", "ER", ex.Message);
            }
            return oDs;
        }
        public DataSet editarContrasenya( string pUsuario, string pContrasenyaAnt, string pContrasenyaNew, bool pFlagEnabled ) {
            DataSet oDs = new DataSet();
            try {
                DirectoryEntry oDeActiveDirectory = new DirectoryEntry(@"LDAP://" + vgLogRoot + vgUnidadOrg, vgDomain + @"\" + pUsuario, pContrasenyaAnt, AuthenticationTypes.None);
                object oNatObject = oDeActiveDirectory.NativeObject;
                oDeActiveDirectory = new DirectoryEntry(@"LDAP://" + vgLogRoot + vgUnidadOrg, vgDomain + @"\" + vgUserAdmin, vgPassAdmin, AuthenticationTypes.None);
                DirectoryEntry oDeUser = oDeActiveDirectory.Children.Find("CN=" + pUsuario, "User");
                oDeUser.Invoke("SetPassword", new object[] { pContrasenyaNew });
                oDeUser.CommitChanges();
                //cuenta habilitada/deshabilitada
                int vOldUAC = (int)oDeUser.Properties["userAccountControl"][0];
                int vFlagCuentaDeshabilitada = 2;
                if (pFlagEnabled)
                    oDeUser.Properties["userAccountControl"][0] = (vOldUAC & ~vFlagCuentaDeshabilitada);
                else
                    oDeUser.Properties["userAccountControl"][0] = (vOldUAC | vFlagCuentaDeshabilitada);
                oDeUser.CommitChanges();
                // pass never expires
                int vFlagExpire = 0x10000;
                int vValue = (int)oDeUser.Properties["userAccountControl"].Value;
                oDeUser.Properties["userAccountControl"].Value = vValue | vFlagExpire;
                oDeUser.CommitChanges();
                oDeActiveDirectory.Close();
                oDeUser.Close();
                oDs = ObjectUtils.generarDsOk();
            } catch (DirectoryServicesCOMException ex) {
                Console.WriteLine("{0} Exception caught.", ex);
                oDs = ObjectUtils.generarDsMensaje("0", "ER", "Nombre de usuario desconocido o contraseña incorrecta.");
            } catch (System.Reflection.TargetInvocationException ex) {
                oDs = ObjectUtils.generarDsMensaje("0", "ER", ex.Message);
            } catch (Exception ex) {
                oDs = ObjectUtils.generarDsMensaje("0", "ER", ex.Message);
            }
            return oDs;
        }
        public DataSet editarContrasenya( string pUsuario, string pContrasenyaNew, bool pFlagEnabled ) {
            DataSet oDs = new DataSet();
            try {
                DirectoryEntry oDeActiveDirectory = new DirectoryEntry(@"LDAP://" + vgLogRoot + vgUnidadOrg, vgDomain + @"\" + vgUserAdmin, vgPassAdmin, AuthenticationTypes.None);
                DirectoryEntry oDeUser = oDeActiveDirectory.Children.Find("CN=" + pUsuario, "User");
                oDeUser.Invoke("SetPassword", new object[] { pContrasenyaNew });
                oDeUser.CommitChanges();
                //cuenta habilitada/deshabilitada
                int vOldUAC = (int)oDeUser.Properties["userAccountControl"][0];
                int vFlagCuentaDeshabilitada = 2;
                if (pFlagEnabled)
                    oDeUser.Properties["userAccountControl"][0] = (vOldUAC & ~vFlagCuentaDeshabilitada);
                else
                    oDeUser.Properties["userAccountControl"][0] = (vOldUAC | vFlagCuentaDeshabilitada);
                oDeUser.CommitChanges();
                // pass never expires
                int vFlagExpire = 0x10000;
                int vValue = (int)oDeUser.Properties["userAccountControl"].Value;
                oDeUser.Properties["userAccountControl"].Value = vValue | vFlagExpire;
                oDeUser.CommitChanges();
                oDeActiveDirectory.Close();
                oDeUser.Close();
                oDs = ObjectUtils.generarDsOk();
            } catch (DirectoryServicesCOMException ex) {
                Console.WriteLine("{0} Exception caught.", ex);
                oDs = ObjectUtils.generarDsMensaje("0", "ER", "Nombre de usuario desconocido o contraseña incorrecta.");
            } catch (System.Reflection.TargetInvocationException ex) {
                oDs = ObjectUtils.generarDsMensaje("0", "ER", ex.Message);
            } catch (Exception ex) {
                oDs = ObjectUtils.generarDsMensaje("0", "ER", ex.Message);
            }
            return oDs;
        }
        public DataSet editarContrasenya( string pUsuario ) {
            DataSet oDs = new DataSet();
            try {
                DirectoryEntry oDeActiveDirectory = new DirectoryEntry(@"LDAP://" + vgLogRoot + vgUnidadOrg, vgDomain + @"\" + vgUserAdmin, vgPassAdmin, AuthenticationTypes.None);
                DirectoryEntry oDeUser = oDeActiveDirectory.Children.Find("CN=" + pUsuario, "User");
                oDeUser.InvokeSet("AccountExpirationDate", new object[] { new DateTime(2099, 12, 29) });
                oDeUser.CommitChanges();
                // pass never expires
                int vFlagExpire = 0x10000;
                int vValue = (int)oDeUser.Properties["userAccountControl"].Value;
                oDeUser.Properties["userAccountControl"].Value = vValue | vFlagExpire;
                oDeUser.CommitChanges();
                oDeActiveDirectory.Close();
                oDeUser.Close();
                oDs = ObjectUtils.generarDsOk();
            } catch (DirectoryServicesCOMException ex) {
                Console.WriteLine("{0} Exception caught.", ex);
                oDs = ObjectUtils.generarDsMensaje("0", "ER", "Nombre de usuario desconocido o contraseña incorrecta.");
            } catch (System.Reflection.TargetInvocationException ex) {
                oDs = ObjectUtils.generarDsMensaje("0", "ER", ex.Message);
            } catch (Exception ex) {
                oDs = ObjectUtils.generarDsMensaje("0", "ER", ex.Message);
            }
            return oDs;
        }
        public DataSet editarEstado( string pUsuario, bool pFlagEnabled ) {
            DataSet oDs = new DataSet();
            try {
                DirectoryEntry oDeActiveDirectory = new DirectoryEntry(@"LDAP://" + vgLogRoot + vgUnidadOrg, vgDomain + @"\" + vgUserAdmin, vgPassAdmin, AuthenticationTypes.None);
                DirectoryEntry oDeUser = oDeActiveDirectory.Children.Find("CN=" + pUsuario, "User");

                //cuenta habilitada/deshabilitada
                int vOldUAC = (int)oDeUser.Properties["userAccountControl"][0];
                int vFlagCuentaDeshabilitada = 2;
                if (pFlagEnabled)
                    oDeUser.Properties["userAccountControl"][0] = (vOldUAC & ~vFlagCuentaDeshabilitada);
                else
                    oDeUser.Properties["userAccountControl"][0] = (vOldUAC | vFlagCuentaDeshabilitada);
                oDeUser.CommitChanges();
                oDeActiveDirectory.Close();
                oDeUser.Close();
                oDs = ObjectUtils.generarDsOk();
            } catch (DirectoryServicesCOMException ex) {
                Console.WriteLine("{0} Exception caught.", ex);
                oDs = ObjectUtils.generarDsMensaje("0", "ER", "Nombre de usuario desconocido o contraseña incorrecta.");
            } catch (System.Reflection.TargetInvocationException ex) {
                oDs = ObjectUtils.generarDsMensaje("0", "ER", ex.Message);
            } catch (Exception ex) {
                oDs = ObjectUtils.generarDsMensaje("0", "ER", ex.Message);
            }
            return oDs;
        }
        public DataSet validarCuentaUsuario( string pUsuario, string pContrasenya ) {
            DataSet oDs = new DataSet();
            try {
                DirectoryEntry oDeActiveDirectory = new DirectoryEntry(@"LDAP://" + vgLogRoot + vgUnidadOrg, vgDomain + @"" + pUsuario, pContrasenya, AuthenticationTypes.None);
                object oNatObject = oDeActiveDirectory.NativeObject;
                oDs = ObjectUtils.generarDsOk();
            } catch (DirectoryServicesCOMException ex) {
                if (ex.ExtendedErrorMessage.Contains("data 525"))
                    oDs = ObjectUtils.generarDsMensaje("1317", "ER", "[AD] Nombre de usuario desconocido.");
                else if (ex.ExtendedErrorMessage.Contains("data 52e"))
                    oDs = ObjectUtils.generarDsMensaje("1326", "ER", "[AD] Usuario desconocido o contraseña incorrecta.");
                else if (ex.ExtendedErrorMessage.Contains("data 52f"))
                    oDs = ObjectUtils.generarDsMensaje("1327", "ER", "[AD] la cuenta de usuario se encuentra restringida.");
                else if (ex.ExtendedErrorMessage.Contains("data 530"))
                    oDs = ObjectUtils.generarDsMensaje("1328", "ER", "[AD] No se puede realizar el login en este instante, favor de intentarlo más tarde.");
                else if (ex.ExtendedErrorMessage.Contains("data 531"))
                    oDs = ObjectUtils.generarDsMensaje("1329", "ER", "[AD] No se puede realizar el login en el servidor.");
                else if (ex.ExtendedErrorMessage.Contains("data 532"))
                    oDs = ObjectUtils.generarDsMensaje("1330", "ER", "[AD] Su contraseña ha caducado, favor de cambiarla.");
                else if (ex.ExtendedErrorMessage.Contains("data 533"))
                    oDs = ObjectUtils.generarDsMensaje("1331", "ER", "[AD] La cuenta de usuario no se encuentra activa.");
                else if (ex.ExtendedErrorMessage.Contains("data 534"))
                    oDs = ObjectUtils.generarDsMensaje("1332", "ER", "[AD] No cuenta con el permiso para realizar esta operación.");
                else if (ex.ExtendedErrorMessage.Contains("data 701"))
                    oDs = ObjectUtils.generarDsMensaje("1793", "ER", "[AD] La cuenta de usuario ha expirado.");
                else if (ex.ExtendedErrorMessage.Contains("data 773"))
                    oDs = ObjectUtils.generarDsMensaje("1907", "ER", "[AD] Debe cambiar su contraseña antes de poder ingresar.");
                else if (ex.ExtendedErrorMessage.Contains("data 775"))
                    oDs = ObjectUtils.generarDsMensaje("1909", "ER", "[AD] La cuenta de usuario ha sido bloqueado por seguridad.");
                else
                    oDs = ObjectUtils.generarDsMensaje("0", "ER", "[AD] " + ex.Message);
            } catch (System.Reflection.TargetInvocationException ex) {
                oDs = ObjectUtils.generarDsMensaje("0", "ER", "[AD] " + ex.Message);
            } catch (Exception ex) {
                oDs = ObjectUtils.generarDsMensaje("0", "ER", "[AD] " + ex.Message);
            }
            return oDs;
        }
        public DataSet validarCuentaUsuario2( string pUsuario ) {
            DataSet oDs = new DataSet();
            oDs = ObjectUtils.generarDsMensaje("0", "RN", "El usuario " + pUsuario + " No Existe en el dominio " + vgDomain);
            try {
                using (var context = new PrincipalContext(ContextType.Domain, vgDomain)) {
                    using (var searcher = new PrincipalSearcher(new UserPrincipal(context))) {
                        foreach (var result in searcher.FindAll()) {
                            DirectoryEntry entry = result.GetUnderlyingObject() as DirectoryEntry;
                            if (entry.Properties["samAccountName"].Value.ToString() == pUsuario)
                                oDs = ObjectUtils.generarDsOk();
                        }
                    }
                }
            } catch (DirectoryServicesCOMException ex) {
                Console.WriteLine("{0} Exception caught.", ex);
                oDs = ObjectUtils.generarDsMensaje("0", "ER", "El usuario no esxiste en el servidor");
            } catch (Exception ex) {
                oDs = ObjectUtils.generarDsMensaje("0", "RN", ex.Message);
            }
            return oDs;
        }

    public List<User> ConsultarUsuarios() {
        List<User> rst = new List<User>();

        string DomainPath = "LDAP://OU=Cenares,DC=cenares,DC=gob,DC=pe";
        DirectoryEntry adSearchRoot = new DirectoryEntry(DomainPath);
        DirectorySearcher adSearcher = new DirectorySearcher(adSearchRoot);

        adSearcher.Filter = "(&(objectClass=user)(objectCategory=person))";
        adSearcher.PropertiesToLoad.Add("samaccountname");
        adSearcher.PropertiesToLoad.Add("title");
        adSearcher.PropertiesToLoad.Add("mail");
        adSearcher.PropertiesToLoad.Add("usergroup");
        adSearcher.PropertiesToLoad.Add("company");
        adSearcher.PropertiesToLoad.Add("department");
        adSearcher.PropertiesToLoad.Add("telephoneNumber");
        adSearcher.PropertiesToLoad.Add("mobile");
        adSearcher.PropertiesToLoad.Add("displayname");
        SearchResult result;
        SearchResultCollection iResult = adSearcher.FindAll();

        User item;
        if (iResult != null) {
            for (int counter = 0; counter < iResult.Count; counter++) {
                result = iResult[counter];
                if (result.Properties.Contains("samaccountname")) {
                    item = new User();

                    item.UserName = (String)result.Properties["samaccountname"][0];

                    if (result.Properties.Contains("displayname")) {
                        item.DisplayName = (String)result.Properties["displayname"][0];
                    }

                    if (result.Properties.Contains("mail")) {
                        item.Email = (String)result.Properties["mail"][0];
                    }

                    if (result.Properties.Contains("company")) {
                        item.Company = (String)result.Properties["company"][0];
                    }

                    if (result.Properties.Contains("title")) {
                        item.JobTitle = (String)result.Properties["title"][0];
                    }

                    if (result.Properties.Contains("department")) {
                        item.Deparment = (String)result.Properties["department"][0];
                    }

                    if (result.Properties.Contains("telephoneNumber")) {
                        item.Phone = (String)result.Properties["telephoneNumber"][0];
                    }

                    if (result.Properties.Contains("mobile")) {
                        item.Mobile = (String)result.Properties["mobile"][0];
                    }
                    rst.Add(item);
                }
            }
        }

        adSearcher.Dispose();
        adSearchRoot.Dispose();

        return rst;
    }

    public class User {
        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string Company { get; set; }

        public string Deparment { get; set; }

        public string JobTitle { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }
    }

}