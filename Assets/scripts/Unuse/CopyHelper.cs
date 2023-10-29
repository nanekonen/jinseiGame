using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// �R�s�[�p�ėp�֐�
/// </summary>
public static class CopyHelper
{
    /// <summary>
    /// �Ώۂ̃f�B�[�v�R�s�[���s��
    /// �V���A���C�Y(Serializable ����)����Ă��Ȃ��N���X�ł̓G���[
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="src"></param>
    /// <returns></returns>
    public static T DeepCopy<T>(this T src)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, src);
            stream.Position = 0;

            return (T)formatter.Deserialize(stream);
        }
    }
}