using System;
using System.Runtime.InteropServices;

internal class Class43
{
	[global::System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = global::System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
	[return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.Bool)]
	private static extern bool CopyFileEx(string string_0, string string_1, global::Class43.Delegate1 delegate1_0, global::System.IntPtr intptr_0, ref int int_1, global::Class43.Enum6 enum6_0);

	public void method_0(string string_0, string string_1)
	{
		global::Class43.CopyFileEx(string_0, string_1, new global::Class43.Delegate1(this.method_1), global::System.IntPtr.Zero, ref this.int_0, (global::Class43.Enum6)10U);
	}

	private global::Class43.Enum4 method_1(long long_0, long long_1, long long_2, long long_3, uint uint_0, global::Class43.Enum5 enum5_0, global::System.IntPtr intptr_0, global::System.IntPtr intptr_1, global::System.IntPtr intptr_2)
	{
		return (global::Class43.Enum4)0U;
	}

	public Class43()
	{
		
	}

	private int int_0;

	private delegate global::Class43.Enum4 Delegate1(long TotalFileSize, long TotalBytesTransferred, long StreamSize, long StreamBytesTransferred, uint dwStreamNumber, global::Class43.Enum5 dwCallbackReason, global::System.IntPtr hSourceFile, global::System.IntPtr hDestinationFile, global::System.IntPtr lpData);

	private enum Enum4 : uint
	{

	}

	private enum Enum5 : uint
	{

	}

	[global::System.Flags]
	private enum Enum6 : uint
	{

	}
}
