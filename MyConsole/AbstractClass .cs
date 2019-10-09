using System;

public abstract class A
{
	public abstract string Say();
	public abstract string Cry();
}
public abstract class B : A
{
	public override string Say() { return "Say: I am B : A"; }
}
public class C : B
{
	public override string Cry() { return "Cry: I am C : B"; }
}
