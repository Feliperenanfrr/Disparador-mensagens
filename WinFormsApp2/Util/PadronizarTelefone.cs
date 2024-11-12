using PhoneNumbers;

namespace Gweb.WhatsApp.Util
{
    class PadronizarTelefone
    {
        public static string PadronizaTelefone(string numero)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();

            try
            {
                var converteNumero = phoneNumberUtil.Parse(numero, "BR");

                if (!phoneNumberUtil.IsValidNumber(converteNumero))
                {
                    return phoneNumberUtil.Format(converteNumero, PhoneNumberFormat.E164).Replace("+", "");
                }
                else
                {
                    return null;
                }
            }
            catch (NumberParseException)
            {
                return null;
            }
        }

    }
}
