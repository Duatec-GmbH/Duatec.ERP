using CSScriptLib;
using System;
using System.Collections.Generic;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Web.Service
{
	public static class CodeEvalService
	{
		private static readonly object lockObj = new object();
		private static readonly Dictionary<string, object> scriptObjects = [];

		private static ICodeVariable GetScriptObject(string sourceCode)
		{
			if (string.IsNullOrWhiteSpace(sourceCode))
				throw new ArgumentException("SourceCode is empty");

			string md5Key = sourceCode;
			if (scriptObjects.ContainsKey(md5Key))
				return scriptObjects[md5Key] as ICodeVariable;

			lock (lockObj)
			{

				//dublication of MD5 hash, so we stopped using it
				//string md5Key = CalculateMD5Hash(sourceCode);
				if (scriptObjects.ContainsKey(md5Key))
					return scriptObjects[md5Key] as ICodeVariable;

				CSScript.EvaluatorConfig.ReferenceDomainAssemblies = true;
				ICodeVariable scriptObject = CSScript.Evaluator.LoadCode<ICodeVariable>(sourceCode);
				scriptObjects[md5Key] = scriptObject;
				return scriptObject;
			}
		}

		public static object Evaluate(string sourceCode, BaseErpPageModel pageModel)
		{
			ICodeVariable script = GetScriptObject(sourceCode);
			return script.Evaluate(pageModel);
		}

		internal static void Compile(string sourceCode)
		{
			GetScriptObject(sourceCode);
		}
	}
}
