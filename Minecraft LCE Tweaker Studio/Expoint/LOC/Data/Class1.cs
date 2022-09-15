using System;
using System.IO;
using System.Text;

internal class Class47
{
	public Class47()
	{
		
		this.bool_0 = true;
	}

	public Class47(bool bool_1)
	{
		
		this.bool_0 = true;
		this.bool_0 = bool_1;
	}

	public bool method_0()
	{
		return this.bool_0;
	}

	public void method_1(bool bool_1)
	{
		this.bool_0 = bool_1;
	}

	internal short method_2(global::System.IO.Stream stream_0)
	{
		byte[] array = this.method_6(stream_0, 2);
		if (global::System.BitConverter.IsLittleEndian && this.method_0())
		{
			global::System.Array.Reverse(array);
		}
		return global::System.BitConverter.ToInt16(array, 0);
	}

	internal ushort method_3(global::System.IO.Stream stream_0)
	{
		byte[] array = this.method_6(stream_0, 2);
		if (global::System.BitConverter.IsLittleEndian && this.method_0())
		{
			global::System.Array.Reverse(array);
		}
		return global::System.BitConverter.ToUInt16(array, 0);
	}

	internal int method_4(global::System.IO.Stream stream_0)
	{
		byte[] array = this.method_6(stream_0, 4);
		if (global::System.BitConverter.IsLittleEndian && this.method_0())
		{
			global::System.Array.Reverse(array);
		}
		return global::System.BitConverter.ToInt32(array, 0);
	}

	internal uint method_5(global::System.IO.Stream stream_0)
	{
		byte[] array = this.method_6(stream_0, 4);
		if (global::System.BitConverter.IsLittleEndian && this.method_0())
		{
			global::System.Array.Reverse(array);
		}
		return global::System.BitConverter.ToUInt32(array, 0);
	}

	private byte[] method_6(global::System.IO.Stream stream_0, int int_0)
	{
		byte[] array = new byte[int_0];
		stream_0.Read(array, 0, int_0);
		return array;
	}

	internal string method_7(global::System.IO.Stream stream_0)
	{
		ushort num = this.method_3(stream_0);
		byte[] array = new byte[(int)num];
		for (int i = 0; i < (int)num; i++)
		{
			byte b = (byte)stream_0.ReadByte();
			array[i] = b;
		}
		global::System.Text.Encoding utf = global::System.Text.Encoding.UTF8;
		return utf.GetString(array);
	}

	internal int method_8(global::System.IO.Stream stream_0)
	{
		int result = this.method_4(stream_0);
		stream_0.Seek(-4L, global::System.IO.SeekOrigin.Current);
		return result;
	}

	internal void method_9(short short_0, global::System.IO.Stream stream_0)
	{
		byte[] bytes = global::System.BitConverter.GetBytes(short_0);
		if (global::System.BitConverter.IsLittleEndian && this.method_0())
		{
			global::System.Array.Reverse(bytes);
		}
		stream_0.Write(bytes, 0, bytes.Length);
	}

	internal void method_10(int int_0, global::System.IO.Stream stream_0)
	{
		byte[] bytes = global::System.BitConverter.GetBytes(int_0);
		if (global::System.BitConverter.IsLittleEndian && this.method_0())
		{
			global::System.Array.Reverse(bytes);
		}
		stream_0.Write(bytes, 0, bytes.Length);
	}

	internal void method_11(uint uint_0, global::System.IO.Stream stream_0)
	{
		byte[] bytes = global::System.BitConverter.GetBytes(uint_0);
		if (global::System.BitConverter.IsLittleEndian && this.method_0())
		{
			global::System.Array.Reverse(bytes);
		}
		stream_0.Write(bytes, 0, bytes.Length);
	}

	internal void method_12(string string_0, global::System.IO.MemoryStream memoryStream_0)
	{
		global::System.Text.Encoding utf = global::System.Text.Encoding.UTF8;
		byte[] bytes = utf.GetBytes(string_0);
		this.method_9((short)bytes.Length, memoryStream_0);
		memoryStream_0.Write(bytes, 0, bytes.Length);
	}

	private bool bool_0;
}
