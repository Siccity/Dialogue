using System;
using System.Linq.Expressions;
using System.Reflection;

public class Function : Function<bool> { }

public abstract class Function<TReturn> : FunctionBase {
	public TReturn Invoke() {
		object o = base.Invoke();
		if (o != null) return (TReturn) o;
		else return default(TReturn);
	}
}

public abstract class Function<T0, TReturn> : FunctionBase {
	public TReturn Invoke(T0 arg0) {
		object o = base.Invoke(arg0);
		if (o != null) return (TReturn) o;
		else return default(TReturn);
	}

	protected override InvokableFunctionBase GetDelegate(MethodInfo methodInfo, object target) {
		return new InvokableFunction<T0>(target, methodInfo);
	}
}

public abstract class Function<T0, T1, TReturn> : FunctionBase {
	public TReturn Invoke(T0 arg0, T1 arg1) {
		object o = base.Invoke(arg0, arg1);
		if (o != null) return (TReturn) o;
		else return default(TReturn);
	}

	protected override InvokableFunctionBase GetDelegate(MethodInfo methodInfo, object target) {
		return new InvokableFunction<T0, T1>(target, methodInfo);
	}
}