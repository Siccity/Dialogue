using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using UnityEngine;

public class InvokableFunction : InvokableFunctionBase {
	public Func<object> func;

	public InvokableFunction(object target, MethodInfo methodInfo, params object[] args) : base(target, methodInfo) {
		func = CacheFunction(methodInfo, target, args);
	}

	public override object Invoke(params object[] args) {
		return func();
	}

	private Func<object> CacheFunction(MethodInfo methodInfo, object target, object[] arguments) {
		ConstantExpression instance = Expression.Constant(target);
		ConstantExpression[] args = arguments.Select(x => Expression.Constant(x)).ToArray();
		MethodCallExpression call = Expression.Call(instance, methodInfo, args);
		UnaryExpression convert = Expression.Convert(call, typeof(object));
		Expression<Func<object>> lambda = Expression.Lambda<Func<object>>(convert);
		return lambda.Compile();
	}
}

public class InvokableFunction<T0> : InvokableFunctionBase {
	public Func<T0, object> func;

	public InvokableFunction(object target, MethodInfo methodInfo, params object[] args) : base(target, methodInfo) {
		func = CacheFunction(methodInfo, target);
	}

	public override object Invoke(params object[] args) {
		return func((T0) args[0]);
	}

	private Func<T0, object> CacheFunction(MethodInfo methodInfo, object target) {
		ConstantExpression instance = Expression.Constant(target);
		ParameterExpression param = Expression.Parameter(typeof(T0), "arg0");
		MethodCallExpression call = Expression.Call(instance, methodInfo, param);
		UnaryExpression convert = Expression.Convert(call, typeof(object));
		Expression<Func<T0, object>> lambda = Expression.Lambda<Func<T0, object>>(convert, param);
		return lambda.Compile();
	}
}

public class InvokableFunction<T0, T1> : InvokableFunctionBase {
	public Func<T0, T1, object> func;

	public InvokableFunction(object target, MethodInfo methodInfo, params object[] args) : base(target, methodInfo) {
		func = CacheFunction(methodInfo, target);
	}

	public override object Invoke(params object[] args) {
		return func((T0) args[0], (T1) args[1]);
	}

	private Func<T0, T1, object> CacheFunction(MethodInfo methodInfo, object target) {
		ConstantExpression instance = Expression.Constant(target);
		ParameterExpression param0 = Expression.Parameter(typeof(T0), "arg0");
		ParameterExpression param1 = Expression.Parameter(typeof(T1), "arg1");
		MethodCallExpression call = Expression.Call(instance, methodInfo, param0, param1);
		UnaryExpression convert = Expression.Convert(call, typeof(object));
		Expression<Func<T0, T1, object>> lambda = Expression.Lambda<Func<T0, T1, object>>(convert, param0, param1);
		return lambda.Compile();
	}
}