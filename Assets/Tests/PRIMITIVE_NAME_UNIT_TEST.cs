using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class PRIMITIVE_NAME_UNIT_TEST
{
    // -- PUBLIC

    // .. TESTS

    [Test]
    public void PRIMITIVE_NAME_UNIT_TESTSimplePasses()
    {
        OperatorEqualTest();
    }
    
    // ~~

    [UnityTest]
    public IEnumerator PRIMITIVE_NAME_UNIT_TESTWithEnumeratorPasses()
    {
        yield return null;
    }

    // .. PRIVATE

    // .. TESTS

    void OperatorEqualTest()
    {
        PRIMITIVE_NAME
            Name0 = new PRIMITIVE_NAME( "Name0" ),
            Name0Second = new PRIMITIVE_NAME( "Name0" ),
            Name1 = new PRIMITIVE_NAME( "Name1" ),
            Name2 = null,
            Name3 = null;

        Assert.AreEqual( Name0, Name0Second );
        Assert.AreEqual( Name2, Name3 );
        Assert.AreEqual( Name2, null );
        Assert.AreNotEqual( Name0, Name1 );
        Assert.AreNotEqual( Name0, null );
        Assert.AreNotEqual( Name0Second, Name1 );
        Assert.AreNotEqual( Name0Second, Name2 );

        Assert.IsTrue( Name0 == Name0Second );
        Assert.IsTrue( Name2 == Name3 );
        Assert.IsTrue( Name2 == null );
        Assert.IsTrue( Name0 != Name1 );
        Assert.IsTrue( Name0 != Name2 );
        Assert.IsTrue( Name0 != null );
        Assert.IsFalse( Name0 == Name1 );
        Assert.IsFalse( Name0 == null );
        Assert.IsFalse( Name0 == Name2 );
        Assert.IsFalse( Name0 != Name0Second );
        Assert.IsFalse( Name2 != Name3 );
        Assert.IsFalse( Name2 != null );

        Assert.AreEqual( Name0.GetHashCode(), Name0Second.GetHashCode() );
        Assert.AreNotEqual( Name1.GetHashCode(), Name0.GetHashCode() );

        Assert.IsTrue( Name0.Equals( Name0Second ) );
        Assert.IsTrue( !Name0.Equals( null ) );
        Assert.IsTrue( !Name0.Equals( Name2 ) );
        Assert.IsFalse( Name1.Equals( Name0Second ) );
        Assert.IsFalse( !Name0.Equals( Name0Second ) );
        Assert.IsFalse( Name1.Equals( Name3 ) );
        Assert.IsFalse( Name1.Equals( null ) );
    }

    // .. ATTRIBUTES

}
