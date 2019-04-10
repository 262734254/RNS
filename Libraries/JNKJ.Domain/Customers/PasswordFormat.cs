
namespace JNKJ.Domain.Customers
{
    public enum PasswordFormat : int
    {
        //不加密
        Clear = 0,
        //哈希加密
        Hashed = 1,
        //RSA加密
        Encrypted = 2,
        //MD5加密
        MD5 = 3
    }
}
