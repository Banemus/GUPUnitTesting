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
        ReadGuidTest();
        ReadDateTimeTest();
        ReadTimeSpanTest();
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

    // ~~

    void ReadGuidTest()
    {
        using ( MemoryStream stream = new MemoryStream() )
        {
            System.Guid
                guid,
                empty_guid;

            guid = System.Guid.NewGuid();
            empty_guid = System.Guid.Empty;

            using( BINARY_WRITER_EXTENDED writer = new BINARY_WRITER_EXTENDED( stream ) )
            {
                writer.Write( guid );
                writer.Write( empty_guid );
                writer.Write( guid );
            }

            stream.Flush();

            using( MemoryStream out_stream = new MemoryStream( stream.GetBuffer() ) )
            {
                using ( BINARY_READER_EXTENDED reader = new BINARY_READER_EXTENDED( out_stream ) )
                {
                    Assert.IsTrue( reader.ReadGuid().Equals( guid ) );
                    Assert.IsTrue( reader.ReadGuid().Equals( empty_guid ) );
                    Assert.IsTrue( reader.ReadGuid().Equals( guid ) );
                }
            }
        }
    }

    // ~~

    void ReadDateTimeTest()
    {
        using ( MemoryStream stream = new MemoryStream() )
        {
            System.DateTime
                date_time,
                empty_date_time;

            date_time = System.DateTime.Now;
            empty_date_time = new System.DateTime();

            using( BINARY_WRITER_EXTENDED writer = new BINARY_WRITER_EXTENDED( stream ) )
            {
                writer.Write( date_time );
                writer.Write( empty_date_time );
                writer.Write( date_time );
            }

            stream.Flush();

            using( MemoryStream out_stream = new MemoryStream( stream.GetBuffer() ) )
            {
                using ( BINARY_READER_EXTENDED reader = new BINARY_READER_EXTENDED( out_stream ) )
                {
                    Assert.AreEqual( reader.ReadDateTime(), date_time );
                    Assert.AreEqual( reader.ReadDateTime(), empty_date_time );
                    Assert.AreEqual( reader.ReadDateTime(), date_time );
                }
            }
        }
    }

    // ~~

    void ReadTimeSpanTest()
    {
        using ( MemoryStream stream = new MemoryStream() )
        {
            System.TimeSpan
                time_span,
                empty_time_span;

            time_span = System.DateTime.Now - System.DateTime.UtcNow;
            empty_time_span = new System.TimeSpan();

            using( BINARY_WRITER_EXTENDED writer = new BINARY_WRITER_EXTENDED( stream ) )
            {
                writer.Write( time_span );
                writer.Write( empty_time_span );
                writer.Write( time_span );
            }

            stream.Flush();

            using( MemoryStream out_stream = new MemoryStream( stream.GetBuffer() ) )
            {
                using ( BINARY_READER_EXTENDED reader = new BINARY_READER_EXTENDED( out_stream ) )
                {
                    Assert.AreEqual( reader.ReadTimeSpan(), time_span );
                    Assert.AreEqual( reader.ReadTimeSpan(), empty_time_span );
                    Assert.AreEqual( reader.ReadTimeSpan(), time_span );
                }
            }
        }
    }
}
