using System.Text.Json;

namespace DesafioPorter.Helpers
{
    public class ObjectSerializedEqualityComparer : IEqualityComparer<object>
    {
        public bool Equals(object b1, object b2)
        {
            return JsonSerializer.Serialize(b1).Equals(JsonSerializer.Serialize(b2));
        }

        public int GetHashCode(object obj)
        {
            return JsonSerializer.Serialize(obj).GetHashCode();
        }
    }
}
