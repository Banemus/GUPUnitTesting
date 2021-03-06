﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BINARY_READER_WRITER_EXTENDED_UNIT_TEST
{
    // -- PUBLIC

    // .. TESTS

    [Test]
    public void BINARY_READER_WRITER_EXTENDED_UNIT_TEST_SIMPLE_PASSES()
    {
        ReadBasicString();
        ReadEmptyString();
    }
    
    // ~~

    [UnityTest]
    public IEnumerator BINARY_READER_WRITER_EXTENDED_UNIT_TEST_WITH_ENUMERATOR_PASSES()
    {
        yield return null;
    }

    // -- PRIVATE

    // .. TESTS

    void ReadBasicString()
    {
        using ( MemoryStream stream = new MemoryStream() )
        {
            string
                test;

            test = "test";

            using( IO_BINARY_WRITER_EXTENDED writer = new IO_BINARY_WRITER_EXTENDED( stream ) )
            {
                writer.Write( test );
            }

            stream.Flush();

            using( MemoryStream out_stream = new MemoryStream( stream.GetBuffer() ) )
            {
                using ( IO_BINARY_READER_EXTENDED reader = new IO_BINARY_READER_EXTENDED( out_stream ) )
                {
                    Assert.AreEqual( "test", reader.ReadString() );
                }
            }
        }
    }

    // ~~

    void ReadEmptyString()
    {
        using ( MemoryStream stream = new MemoryStream() )
        {
            string
                test;

            test = string.Empty;

            using( IO_BINARY_WRITER_EXTENDED writer = new IO_BINARY_WRITER_EXTENDED( stream ) )
            {
                writer.Write( test );
            }

            stream.Flush();

            using( MemoryStream out_stream = new MemoryStream( stream.GetBuffer() ) )
            {
                using ( IO_BINARY_READER_EXTENDED reader = new IO_BINARY_READER_EXTENDED( out_stream ) )
                {
                    Assert.AreEqual( test, reader.ReadString() );
                }
            }
        }
    }
}
