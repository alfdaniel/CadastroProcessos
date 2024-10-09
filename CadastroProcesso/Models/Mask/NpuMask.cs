
using AutoMapper;

namespace CadastroProcesso.Models.Mask
{
    public class NpuMask : IValueConverter<string?, string>
    {

        public string Convert(string? sourceMember, ResolutionContext context)
        {
            if (sourceMember != null)
            {
                var numeros = new string(sourceMember.Where(char.IsDigit).ToArray());
                if (numeros.Length == 20)
                {
                    return numeros.Substring(0, 7)
                        + "-" + numeros.Substring(7, 2)
                        + "." + numeros.Substring(9, 4)
                        + "." + numeros.Substring(13, 1)
                        + "." + numeros.Substring(14, 2)
                        + "." + numeros.Substring(16, 4);
                }
                return sourceMember;
            }
            return string.Empty;
        }

    }
}
