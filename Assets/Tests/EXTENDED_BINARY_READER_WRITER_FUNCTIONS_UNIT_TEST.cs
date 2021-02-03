using System.Collections;
using System.Linq;
using System.IO;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EXTENDED_BINARY_READER_WRITER_FUNCTIONS_UNIT_TEST
{
    // -- PUBLIC

    // .. TESTS

    [Test]
    public void EXTENDED_BINARY_READER_WRITER_FUNCTIONS_UNIT_TEST_SIMPLE_PASSES()
    {
        ReadInt32TableTest();   
        ReadStringTableTest();
    }
    
    // ~~

    [UnityTest]
    public IEnumerator EXTENDED_BINARY_READER_WRITER_FUNCTIONS_UNIT_TEST_WITH_ENUMERATOR_PASSES()
    {
        yield return null;
    }

    // -- PRIVATE

    // .. TESTS

    void ReadInt32TableTest()
    {
        using ( MemoryStream stream = new MemoryStream() )
        {
            int[]
                filled_table,
                empty_table;

            filled_table = new int[]{ 0, 1, 2, 3, 4 };
            empty_table = new int[ 0 ];

            using( BINARY_WRITER_EXTENDED writer = new BINARY_WRITER_EXTENDED( stream ) )
            {
                writer.Write( filled_table );
                writer.Write( empty_table );
                writer.Write( filled_table );
            }

            stream.Flush();

            using( MemoryStream out_stream = new MemoryStream( stream.GetBuffer() ) )
            {
                using ( BINARY_READER_EXTENDED reader = new BINARY_READER_EXTENDED( out_stream ) )
                {
                    Assert.IsTrue( reader.ReadInt32Table().SequenceEqual( filled_table ) );
                    Assert.IsTrue( reader.ReadInt32Table().SequenceEqual( empty_table ) );
                    Assert.IsTrue( reader.ReadInt32Table().SequenceEqual( filled_table ) );
                }
            }
        }
    }

    // ~~

    void ReadStringTableTest()
    {
        using ( MemoryStream stream = new MemoryStream() )
        {
            string[]
                filled_table,
                empty_table;

            filled_table = new string[]{ "test0", "test1", "test2", "test3", "test4" };
            empty_table = new string[ 0 ];

            using( BINARY_WRITER_EXTENDED writer = new BINARY_WRITER_EXTENDED( stream ) )
            {
                writer.Write( filled_table );
                writer.Write( empty_table );
                writer.Write( filled_table );
            }

            stream.Flush();

            using( MemoryStream out_stream = new MemoryStream( stream.GetBuffer() ) )
            {
                using ( BINARY_READER_EXTENDED reader = new BINARY_READER_EXTENDED( out_stream ) )
                {
                    Assert.IsTrue( reader.ReadStringTable().SequenceEqual( filled_table ) );
                    Assert.IsTrue( reader.ReadStringTable().SequenceEqual( empty_table ) );
                    Assert.IsTrue( reader.ReadStringTable().SequenceEqual( filled_table ) );
                }
            }
        }
    }
}
