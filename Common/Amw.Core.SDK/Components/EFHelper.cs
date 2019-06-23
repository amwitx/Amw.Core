using System;
using System.Transactions;

namespace Amw.Core.SDK.Components
{
    public class EFHelper
    {
        /// <summary>
        /// 查询数据，执行NOLOCK
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="execResult"></param>
        /// <returns></returns>
        public T WithNolock<T>(Func<T> execResult) where T : new()
        {
            var result = new T();
            var transactionOptions = new TransactionOptions();
            //设置只读不提交事务
            transactionOptions.IsolationLevel = IsolationLevel.ReadUncommitted;
            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
            {
                try
                {
                    result = execResult();
                }
                finally
                {
                    scope.Complete();
                }
            }
            return result;
        }

        /// <summary>
        /// 查询数据，执行NOLOCK，不返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="execResult"></param>
        /// <returns></returns>
        public void WithNolockVoid(Action execResult)
        {
            var transactionOptions = new TransactionOptions();
            //设置只读不提交事务
            transactionOptions.IsolationLevel = IsolationLevel.ReadUncommitted;
            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
            {
                try
                {
                    execResult();
                }
                finally
                {
                    scope.Complete();
                }
            }
        }
    }
}