using System.Linq;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class COLLECTION_INDEXED_LIST_UNITY_TEST
{
    // -- PUBLIC

    // .. TYPES

    public class TEST
    {
        // -- PUBLIC

        // .. ATTRIBUTES

        public int
            Index;
    }

    // .. TESTS

    [Test]
    public void COLLECTION_INDEXED_LIST_UNITY_TESTSimplePasses()
    {
        OperatorSquareBracketsTest();
        CountTest();
        InsertTest();
        InsertRangeTest();
        GetAllValidValuesTest();
        TryInsertTest();
        GetIndexedValuesTest();
    }
    
    // ~~

    [UnityTest]
    public IEnumerator COLLECTION_INDEXED_LIST_UNITY_TESTWithEnumeratorPasses()
    {
        yield return null;
    }

    // -- PRIVATE

    // .. TESTS

    void OperatorSquareBracketsTest()
    {
        COLLECTION_INDEXED_LIST< TEST >
            table;

        table = new COLLECTION_INDEXED_LIST<TEST>();

        table.Insert( 1, test1 );
        table.Insert( 3, test3 );
        table.Insert( 4, test4 );

        Assert.IsTrue( table[ 0 ] == null );
        Assert.IsTrue( table[ 1 ] == test1 );
        Assert.IsTrue( table[ 2 ] == null );
        Assert.IsTrue( table[ 3 ] == test3 );
        Assert.IsTrue( table[ 4 ] == test4 );
    }

    // ~~

    void CountTest()
    {
        COLLECTION_INDEXED_LIST< TEST >
            table;

        table = new COLLECTION_INDEXED_LIST<TEST>();

        table.Insert( 1, test1 );
        table.Insert( 3, test3 );
        table.Insert( 4, test4 );

        Assert.IsTrue( table.Count == 5 );

        table = new COLLECTION_INDEXED_LIST<TEST>();

        table.InsertRange(
            new KeyValuePair< int, TEST > []
            {
                new KeyValuePair<int, TEST>( test1.Index, test1 ),
                new KeyValuePair<int, TEST>( test3.Index, test3 ),
                new KeyValuePair<int, TEST>( test3.Index, test3 ),
                new KeyValuePair<int, TEST>( test4.Index, test4 ),
                new KeyValuePair<int, TEST>( test4.Index, test4 ),
                new KeyValuePair<int, TEST>( test4.Index, test4 ),
                new KeyValuePair<int, TEST>( test4.Index, test4 )
            }
        );
        
        Assert.IsTrue( table.Count == 5 );
    }

    // ~~

    void InsertTest()
    {
        COLLECTION_INDEXED_LIST< TEST >
            table;

        table = new COLLECTION_INDEXED_LIST<TEST>();

        table.Insert( 1, test1 );
        table.Insert( 3, test3 );
        table.Insert( 4, test4 );

        Assert.IsTrue( table[ 0 ] == null );
        Assert.IsTrue( table[ 1 ] == test1 );
        Assert.IsTrue( table[ 2 ] == null );
        Assert.IsTrue( table[ 3 ] == test3 );
        Assert.IsTrue( table[ 4 ] == test4 );

        table.Insert( 2, test2 );
        
        Assert.IsTrue( table[ 2 ] == test2 );
        
        table.Insert( 2, test3 );
        
        Assert.IsTrue( table[ 2 ] == test3 );
    }

    // ~~

    void InsertRangeTest()
    {
        COLLECTION_INDEXED_LIST< TEST >
            table;

        table = new COLLECTION_INDEXED_LIST<TEST>();

        table.InsertRange(
            new KeyValuePair< int, TEST > []
            {
                new KeyValuePair<int, TEST>( test1.Index, test1 ),
                new KeyValuePair<int, TEST>( test3.Index, test3 ),
                new KeyValuePair<int, TEST>( test4.Index, test4 )
            }
        );

        Assert.IsTrue( table[ 0 ] == null );
        Assert.IsTrue( table[ 1 ] == test1 );
        Assert.IsTrue( table[ 2 ] == null );
        Assert.IsTrue( table[ 3 ] == test3 );
        Assert.IsTrue( table[ 4 ] == test4 );

        
        table.InsertRange(
            new KeyValuePair< int, TEST > []
            {
                new KeyValuePair<int, TEST>( test0.Index, test0 )
            }
        );

        Assert.IsTrue( table[ 0 ] == test0 );

        table.InsertRange(
            new KeyValuePair< int, TEST > []
            {
                new KeyValuePair<int, TEST>( test0.Index, test4 )
            }
        );

        Assert.IsTrue( table[ 0 ] == test4 );
    }

    // ~~

    void GetAllValidValuesTest()
    {
        COLLECTION_INDEXED_LIST< TEST >
            table;

        table = new COLLECTION_INDEXED_LIST<TEST>();
        
        table.InsertRange(
            new KeyValuePair< int, TEST > []
            {
                new KeyValuePair<int, TEST>( test1.Index, test1 ),
                new KeyValuePair<int, TEST>( test3.Index, test3 ),
                new KeyValuePair<int, TEST>( test4.Index, test4 ),
                new KeyValuePair<int, TEST>( test4.Index, test4 ),
                new KeyValuePair<int, TEST>( test4.Index, test4 ),
                new KeyValuePair<int, TEST>( test4.Index, test4 )
            }
        );

        Assert.IsTrue( table.GetAllValidValues().Count() == 3 );
        Assert.IsTrue( table.GetAllValidValues( true ).First() == test1 );
        Assert.IsFalse( table.GetAllValidValues().First() == test1 );
        Assert.IsTrue( table.GetAllValidValues( true ).Last() == test4 );
        Assert.IsFalse( table.GetAllValidValues().Last() == test4 );
    }

    // ~~

    void TryInsertTest()
    {
        COLLECTION_INDEXED_LIST< TEST >
            table;
        TEST
            existing_data;

        table = new COLLECTION_INDEXED_LIST<TEST>();

        Assert.IsTrue( table.TryInsert( 1, test1, out existing_data ) );
        Assert.IsTrue( existing_data == null );
        Assert.IsFalse( table.TryInsert( 1, test2, out existing_data ) );
        Assert.IsTrue( existing_data == test1 );
        Assert.IsTrue( table[ 0 ] == null );
        Assert.IsTrue( table.Count == 2 );
    }

    // ~~

    void GetIndexedValuesTest()
    {
        COLLECTION_INDEXED_LIST< TEST >
            table;

        table = new COLLECTION_INDEXED_LIST<TEST>();
        
        table.InsertRange(
            new KeyValuePair< int, TEST > []
            {
                new KeyValuePair<int, TEST>( test1.Index, test1 ),
                new KeyValuePair<int, TEST>( test3.Index, test3 ),
                new KeyValuePair<int, TEST>( test4.Index, test4 ),
                new KeyValuePair<int, TEST>( test4.Index, test4 ),
                new KeyValuePair<int, TEST>( test4.Index, test4 ),
                new KeyValuePair<int, TEST>( test4.Index, test4 )
            }
        );

        Assert.AreNotEqual( table.GetIndexedValues( 1, 2, 4).Count(), 3 );
        Assert.AreEqual( table.GetIndexedValues( 1, 2, 4).Count(), 2 );
        Assert.AreEqual( table.GetIndexedValues( 1, 3, 4).Count(), 3 );
        Assert.AreEqual( table.GetIndexedValues( 1, 2, 4).First(), test1 );
        Assert.AreNotEqual( table.GetIndexedValues( 1, 2, 4).Last(), test2 );
    }

    // .. ATTRIBUTES

    TEST
        test0 = new TEST{ Index = 0 },
        test1 = new TEST{ Index = 1 },
        test2 = new TEST{ Index = 2 },
        test3 = new TEST{ Index = 3 },
        test4 = new TEST{ Index = 4 };
}
