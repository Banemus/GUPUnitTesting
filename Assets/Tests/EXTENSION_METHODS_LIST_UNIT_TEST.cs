using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EXTENSION_METHODS_LIST_UNIT_TEST
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
    public void EXTENSION_METHODS_LIST_UNIT_TEST_SIMPLE_PASSES()
    {
        RemoveFastTest();
        ContainsOneElementTest();
    }

    // ~~

    [UnityTest]
    public IEnumerator EXTENSION_METHODS_LIST_UNIT_TEST_WITH_ENUMERATOR_PASSES()
    {
        yield return null;
    }

    // -- PRIVATE

    // .. OPERATONS

    void RemoveFastTest()
    {
        List< int >
            int_table;
        List< TEST >
            test_table;
        TEST
            test0,
            test1,
            test2,
            test3,
            test4;

        int_table = new List<int>( new int[]{ 0, 1, 2, 3, 4, 5, 6 } );

        int_table.RemoveAtFast( 2 );

        Assert.IsTrue ( int_table.SequenceEqual( new int[]{ 0, 1, 6, 3, 4, 5 } ) );

        int_table.RemoveAtFast( 3 );

        Assert.IsTrue ( int_table.SequenceEqual( new int[]{ 0, 1, 6, 5, 4 } ) );

        int_table.Add( 7 );

        Assert.IsTrue ( int_table.SequenceEqual( new int[]{ 0, 1, 6, 5, 4, 7 } ) );

        int_table.RemoveAtFast( 0 );
        int_table.RemoveAtFast( 0 );
        int_table.RemoveAtFast( 0 );
        int_table.RemoveAtFast( 0 );
        int_table.RemoveAtFast( 0 );
        int_table.RemoveAtFast( 0 );

        Assert.IsEmpty( int_table );

        test0 = new TEST{ Index = 0 };
        test1 = new TEST{ Index = 1 };
        test2 = new TEST{ Index = 2 };
        test3 = new TEST{ Index = 3 };
        test4 = new TEST{ Index = 4 };

        test_table = new List<TEST>( 
            new TEST[]
            { 
                test0,
                test1,
                test2,
                test3,
                test4
            }
        );

        test_table.RemoveFast( test1 );

        Assert.IsTrue( test_table.SequenceEqual( new TEST[]{ test0, test4, test2, test3 } ) );

        test_table.Add( test1 );

        Assert.IsTrue( test_table.SequenceEqual( new TEST[]{ test0, test4, test2, test3, test1 } ) );

        test_table.RemoveFast( test0 );
        test_table.RemoveFast( test1 );
        test_table.RemoveFast( test2 );
        test_table.RemoveFast( test3 );
        test_table.RemoveFast( test4 );

        Assert.IsEmpty( test_table );
    }

    // ~~

    void ContainsOneElementTest()
    {
        List< TEST >
            test_table,
            test1_table,
            test2_table,
            empty_table;
        TEST
            test0,
            test1,
            test2,
            test3,
            test4,
            test5,
            test6,
            test7,
            test8,
            test9,
            test10;

        test0 = new TEST{ Index = 0 };
        test1 = new TEST{ Index = 1 };
        test2 = new TEST{ Index = 2 };
        test3 = new TEST{ Index = 3 };
        test4 = new TEST{ Index = 4 };
        test5 = new TEST{ Index = 5 };
        test6 = new TEST{ Index = 6 };
        test7 = new TEST{ Index = 7 };
        test8 = new TEST{ Index = 8 };
        test9 = new TEST{ Index = 9 };
        test10 = new TEST{ Index = 10 };

        test_table = new List<TEST>( 
            new TEST[]
            { 
                test0,
                test1,
                test2,
                test3,
                test4,
                test5
            }
        );

        test1_table = new List<TEST>( 
            new TEST[]
            { 
                test5,
                test6,
                test7,
                test8,
            }
        );

        test2_table = new List<TEST>( 
            new TEST[]
            { 
                test9,
                test10
            }
        );

        empty_table = new List<TEST>();

        Assert.IsTrue( test_table.ContainsOneElement( test1_table ) );
        Assert.IsFalse( test1_table.ContainsOneElement( test2_table ) );
        Assert.IsFalse( test1_table.ContainsOneElement( empty_table ) );
    }
}
