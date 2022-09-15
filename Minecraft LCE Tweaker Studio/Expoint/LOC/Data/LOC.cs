using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tweaker.Workers
{

	public class LOC
    {
	}

	public class LanguageBuilder
	{
		public void Build(LanguagesContainer languages, string path)
		{
			using (global::System.IO.BinaryWriter binaryWriter = new global::System.IO.BinaryWriter(global::System.IO.File.Open(path, global::System.IO.FileMode.Create)))
			{
				global::System.IO.Stream baseStream = binaryWriter.BaseStream;
				this.class47_0.method_10(2, baseStream);
				int count = languages.Languages.Count;
				this.class47_0.method_10(count, baseStream);
				baseStream.WriteByte(1);
				int num = languages.Indexes.Length;
				this.class47_0.method_10(num, baseStream);
				for (int i = 0; i < num; i++)
				{
					this.class47_0.method_10(languages.Indexes[i], baseStream);
				}
				byte[] array = this.method_0(languages);
				baseStream.Write(array, 0, array.Length);
			}
		}

		private byte[] method_0(LanguagesContainer languagesContainer_0)
		{
			global::System.IO.MemoryStream memoryStream = new global::System.IO.MemoryStream();
			global::System.IO.MemoryStream memoryStream2 = new global::System.IO.MemoryStream();
			foreach (LanguageEntry languageEntry in languagesContainer_0.Languages.Values)
			{
				byte[] array = this.method_1(languageEntry);
				this.class47_0.method_12(languageEntry.Name, memoryStream);
				this.class47_0.method_10(array.Length, memoryStream);
				memoryStream2.Write(array, 0, array.Length);
			}
			global::System.IO.MemoryStream memoryStream3 = new global::System.IO.MemoryStream();
			byte[] array2 = memoryStream.ToArray();
			memoryStream3.Write(array2, 0, array2.Length);
			array2 = memoryStream2.ToArray();
			memoryStream3.Write(array2, 0, array2.Length);
			return memoryStream3.ToArray();
		}

		private byte[] method_1(LanguageEntry languageEntry_0)
		{
			global::System.IO.MemoryStream memoryStream = new global::System.IO.MemoryStream();
			memoryStream.WriteByte(0);
			this.class47_0.method_10(513, memoryStream);
			this.class47_0.method_12(languageEntry_0.Name, memoryStream);
			this.class47_0.method_10(languageEntry_0.Messages.Count, memoryStream);
			foreach (MessageEntry messageEntry in languageEntry_0.Messages)
			{
				this.class47_0.method_12(messageEntry.Message, memoryStream);
			}
			return memoryStream.ToArray();
		}

		public LanguageBuilder()
		{
			
			this.class47_0 = new global::Class47();
			
		}

		private global::Class47 class47_0;
	}

	public class LanguagesContainer
	{
		public int[] Indexes
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.int_0;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.int_0 = value;
			}
		}

		public global::System.Collections.Generic.Dictionary<string, LanguageEntry> Languages
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.dictionary_0;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.dictionary_0 = value;
			}
		}

		public LanguagesContainer()
		{
			
			
		}

		public LanguagesContainer(int[] indexes, global::System.Collections.Generic.Dictionary<string, LanguageEntry> languages)
		{
			
			
			this.Indexes = indexes;
			this.Languages = languages;
		}

		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int[] int_0;

		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Collections.Generic.Dictionary<string, LanguageEntry> dictionary_0;
	}

	public class LanguageEntry
	{
		public string Name
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.string_0 = value;
			}
		}

		public int Size
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.int_0;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.int_0 = value;
			}
		}

		public global::System.Collections.Generic.List<MessageEntry> Messages
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.list_0;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.list_0 = value;
			}
		}

		public LanguageEntry()
		{
			
			
		}

		public LanguageEntry(string name, int size)
		{
			
			
			this.Name = name;
			this.Size = size;
			this.Messages = new global::System.Collections.Generic.List<MessageEntry>();
		}

		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string string_0;

		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int int_0;

		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Collections.Generic.List<MessageEntry> list_0;
	}

	public class MessageEntry
	{
		public string Message
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.string_0 = value;
			}
		}

		public MessageEntry()
		{
			
		}

		public MessageEntry(string message)
		{
			
			this.Message = message;
		}

		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string string_0;
	}

	public class IndexEntry
	{
		public IndexEntry()
		{
			
			
		}
	}

	public class LanguagesParser
	{
		public LanguagesContainer Parse(byte[] locData)
		{
			LanguagesContainer lc = new LanguagesContainer();
			global::System.IO.MemoryStream s = new global::System.IO.MemoryStream(locData);
			return this.Parse(lc, s);
		}

		public LanguagesContainer Parse(string path)
		{
			LanguagesContainer languagesContainer = new LanguagesContainer();
			if (global::System.IO.File.Exists(path))
			{
				using (global::System.IO.BinaryReader binaryReader = new global::System.IO.BinaryReader(global::System.IO.File.Open(path, global::System.IO.FileMode.Open)))
				{
					global::System.IO.Stream baseStream = binaryReader.BaseStream;
					languagesContainer = this.Parse(languagesContainer, baseStream);
				}
			}
			return languagesContainer;
		}

		public LanguagesContainer Parse(LanguagesContainer lc, global::System.IO.Stream s)
		{
			this.class47_0.method_4(s);
			int num = this.class47_0.method_4(s);
			s.ReadByte();
			int num2 = this.class47_0.method_4(s);
			int[] array = new int[num2];
			for (int i = 0; i < num2; i++)
			{
				array[i] = this.class47_0.method_4(s);
			}
			lc.Indexes = array;
			global::System.Collections.Generic.Dictionary<string, LanguageEntry> dictionary = new global::System.Collections.Generic.Dictionary<string, LanguageEntry>();
			for (int j = 0; j < num; j++)
			{
				string text = this.class47_0.method_7(s);
				int size = this.class47_0.method_4(s);
				LanguageEntry value = new LanguageEntry(text, size);
				dictionary.Add(text, value);
			}
			for (int k = 0; k < num; k++)
			{
				s.ReadByte();
				this.class47_0.method_4(s);
				string key = this.class47_0.method_7(s);
				int num3 = this.class47_0.method_4(s);
				LanguageEntry languageEntry = dictionary[key];
				for (int l = 0; l < num3; l++)
				{
					string message = this.class47_0.method_7(s);
					languageEntry.Messages.Add(new MessageEntry(message));
				}
			}
			lc.Languages = dictionary;
			return lc;
		}

		public LanguagesParser()
		{
			
			this.class47_0 = new global::Class47();
			
		}

		private global::Class47 class47_0;
	}
}
