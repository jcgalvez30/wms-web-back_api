namespace Seguridad;

public class EnviarCorreo {
    public void Email(string sEmail, string sBody, string sAsunto) {
        MailMessage correo = new MailMessage();
        correo.From = new MailAddress("gitlab@cenares.gob.pe", "WMS", System.Text.Encoding.UTF8);
        correo.To.Add(sEmail);
        correo.Subject = sAsunto;
        correo.Body = sBody;
        correo.IsBodyHtml = true;
        correo.Priority = MailPriority.Normal;
        SmtpClient smtp = new SmtpClient();
        smtp.UseDefaultCredentials = false;
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.Credentials = new System.Net.NetworkCredential("gitlab@cenares.gob.pe", "DqE&6dNY");
        ServicePointManager.ServerCertificateValidationCallback = delegate ( object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors ) { return true; };
        smtp.EnableSsl = true;
        smtp.Send(correo);
    }

    public string BodyNuevoUsuario( string sUsuario, string sPassword, string sNombres, string sApellidos ) {
        string htmlString = string.Format(@"<html>
                                                     <body>
                                                        <p>Estimado {0} {1}</p>
                                                        <br>
                                                        <p>Se creo satisfactoriamente su usuario <b>{2}</b>.</p>
                                                        <p>Para poder activar su cuenta debera ingresar al siguiente <a href=""{3}""> LINK </a> y actualizar su contraseña personal.</p>
                                                        <p>El LINK solo se encontrara vigente durante el dia de creación. Si el LINK se encuentra vencido, debera solicitar uno nuevo</p>
                                                     </body>
                                                   </html>", sNombres, sApellidos, sUsuario, "http://DESKTOP-QE80JJK/login/" + sPassword);
        return htmlString;
    }   

    public string BodyReactivarLink( string sUsuario, string sToken, string sNombreCompleto) {
        string htmlString = string.Format(@"<html>
                                                     <body>
                                                        <p>Estimado {0} </p>
                                                        <br>
                                                        <p>Se Reactivo el Link del usuario <b>{1}</b> para que pueda actualizar su contraseña y activar su cuenta</p>
                                                        <p>Para poder activar su cuenta debera ingresar al siguiente <a href=""{2}""> LINK </a> y actualizar su contraseña personal.</p>
                                                        <p>El LINK solo se encontrara vigente durante el dia de creación. Si el LINK se encuentra vencido, debera solicitar uno nuevo</p>
                                                     </body>
                                                   </html>", sNombreCompleto, sUsuario, "http://DESKTOP-QE80JJK/login/" + sToken);
        return htmlString;
    }

    public string BodyReestablecerPassword( string sUsuario, string sToken, string sNombreCompleto ) {
        string htmlString = string.Format(@"<html>
                                                     <body>
                                                        <p>Estimado {0} </p>
                                                        <br>
                                                        <p>Para reestablecer la contraseña del usuario <b>{1}</b> debera ingresar al siguiente <a href=""{2}""> LINK </a> </p>
                                                        <p>El LINK solo se encontrara vigente durante 8 horas. Si el LINK se encuentra vencido, debera solicitar uno nuevo</p>
                                                     </body>
                                                   </html>", sNombreCompleto, sUsuario, "http://DESKTOP-QE80JJK/reestablecercontrasenia?v=" + sToken + "&u=" + sUsuario);
        return htmlString;
    }
}