namespace Seguridad;

public class GeneradorPassword {
    public string GenerarPassword() {
        Random rdn = new Random();
        string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890,@#";
        int longitud = caracteres.Length;
        char letra;
        int longitudContrasenia = 8;
        string contraseniaAleatoria = string.Empty;
        for (int i = 0; i < longitudContrasenia; i++) {
            letra = caracteres[rdn.Next(longitud)];
            contraseniaAleatoria += letra.ToString();
        }
        return contraseniaAleatoria;
    }
}
