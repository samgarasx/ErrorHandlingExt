using System;
using System.Threading.Tasks;

namespace ErrorHandlingExt.Extensions
{
    /// <summary>
    /// Async result extensions class.
    /// </summary>
    public static class AsyncResultExtension
    {
        #region Success Async Result Extension

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TResult>(
            this Task<Result> resultTask, Func<Task<TResult>> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = await func().ConfigureAwait(false);

            return Result<TResult>.FromSuccess(value);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TResult>(
            this Task<Result> resultTask, Func<Task<Result<TResult>>> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return await func().ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> OnSuccess<TSource>(
            this Task<Result<TSource>> resultTask, Func<TSource, Task<Result>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            return await func(result.Value).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> OnSuccess(this Task<Result> resultTask, Func<Task<Result>> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return result;

            return await func().ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TResult>(this Task<Result> resultTask, Func<TResult> func)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TResult>(
            this Task<Result> resultTask, Func<Result<TResult>> func)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> OnSuccess<TSource>(
            this Task<Result<TSource>> resultTask, Func<TSource, Result> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> OnSuccess(this Task<Result> resultTask, Func<Result> func)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TResult>(this Result result, Func<Task<TResult>> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = await func().ConfigureAwait(false);

            return Result<TResult>.FromSuccess(value);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnSuccess<TSource>(
            this Result result, Func<Task<Result<TSource>>> func)
        {
            if (!result.IsSuccess)
                return Result<TSource>.FromFailure(result.Error);

            return await func().ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> OnSuccess<TSource>(
            this Result<TSource> result, Func<TSource, Task<Result>> func)
        {
            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            return await func(result.Value).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> OnSuccess(this Result result, Func<Task<Result>> func)
        {
            if (!result.IsSuccess)
                return result;

            return await func().ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TSource, Task<TResult>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = await func(result.Value);

            return Result<TResult>.FromSuccess(value);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TSource, Task<Result<TResult>>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return await func(result.Value);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<Task<Result<TResult>>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return await func().ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="action">he asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnSuccess<TSource>(
            this Task<Result<TSource>> resultTask, Func<TSource, Task> action)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (result.IsSuccess)
                await action(result.Value).ConfigureAwait(false);

            return result;
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TSource, TResult> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TSource, Result<TResult>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<Result<TResult>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="action">he asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnSuccess<TSource>(
            this Task<Result<TSource>> resultTask, Action<TSource> action)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(action);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Result<TSource> result, Func<TSource, Task<TResult>> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = await func(result.Value).ConfigureAwait(false);

            return Result<TResult>.FromSuccess(value);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Result<TSource> result, Func<TSource, Task<Result<TResult>>> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return await func(result.Value).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Result<TSource> result, Func<Task<Result<TResult>>> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return await func().ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="action">he asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnSuccess<TSource>(
            this Result<TSource> result, Func<TSource, Task> action)
        {
            if (result.IsSuccess)
                await action(result.Value).ConfigureAwait(false);

            return result;
        }

        #endregion

        #region Ensure Async Result Extension

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> with the given error type from an asynchronous conditional method call.
        /// </summary>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="predicate">The asynchronous method to call.</param>
        /// <param name="error">The <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result> Ensure(
            this Task<Result> resultTask, Func<Task<bool>> predicate, Exception error)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            if (!await predicate().ConfigureAwait(false))
                return Result.FromFailure(error);

            return Result.FromSuccess();
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> with the given error type from an asynchronous conditional method call.
        /// </summary>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="predicate">The asynchronous method to call.</param>
        /// <param name="error">The <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result> Ensure(
            this Task<Result> resultTask, Func<bool> predicate, Exception error)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.Ensure(predicate, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> with the given error type from an asynchronous conditional method call.
        /// </summary>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="predicate">The asynchronous method to call.</param>
        /// <param name="error">The <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result> Ensure(this Result result, Func<Task<bool>> predicate, Exception error)
        {
            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            if (!await predicate().ConfigureAwait(false))

                return Result.FromFailure(error);

            return Result.FromSuccess();
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> with the given error type from an asynchronous conditional method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="predicate">The asynchronous method to call.</param>
        /// <param name="error">The <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> Ensure<TSource>(
            this Task<Result<TSource>> resultTask, Func<TSource, Task<bool>> predicate, Exception error)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TSource>.FromFailure(result.Error);

            if (!await predicate(result.Value).ConfigureAwait(false))
                return Result<TSource>.FromFailure(error);

            return Result<TSource>.FromSuccess(result.Value);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> with the given error type from an asynchronous conditional method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="predicate">The asynchronous method to call.</param>
        /// <param name="error">The <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> Ensure<TSource>(
            this Task<Result<TSource>> resultTask, Func<TSource, bool> predicate, Exception error)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);
            return result.Ensure(predicate, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> with the given error type from an asynchronous conditional method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="predicate">The asynchronous method to call.</param>
        /// <param name="error">The <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> Ensure<TSource>(
            this Result<TSource> result, Func<TSource, Task<bool>> predicate, Exception error)
        {
            if (!result.IsSuccess)
                return Result<TSource>.FromFailure(result.Error);

            if (!await predicate(result.Value).ConfigureAwait(false))
                return Result<TSource>.FromFailure(error);

            return Result<TSource>.FromSuccess(result.Value);
        }

        #endregion

        #region Map Async Result Extension

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from an asynchronous mapping method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TResult>(this Task<Result> resultTask, Func<Task<TResult>> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = await func().ConfigureAwait(false);

            return Result<TResult>.FromSuccess(value);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from an asynchronous mapping method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TResult>(this Task<Result> resultTask, Func<TResult> func)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.Map(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from an asynchronous mapping method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TResult>(this Result result, Func<Task<TResult>> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = await func().ConfigureAwait(false);

            return Result<TResult>.FromSuccess(value);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from an asynchronous mapping method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TSource, Task<TResult>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = await func(result.Value).ConfigureAwait(false);

            return Result<TResult>.FromSuccess(value);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from an asynchronous mapping method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TSource, TResult> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);
            return result.Map(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from an asynchronous mapping method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TSource, TResult>(
            this Result<TSource> result, Func<TSource, Task<TResult>> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = await func(result.Value).ConfigureAwait(false);

            return Result<TResult>.FromSuccess(value);
        }

        #endregion

        #region Failure Async Result Extension

        /// <summary>
        /// Returns a failed <see cref="Result"/> from an asynchronous method call.
        /// </summary>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> OnFailure(this Task<Result> resultTask, Func<Task> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                await func().ConfigureAwait(false);

            return result;
        }

        /// <summary>
        /// Returns a failed <see cref="Result"/> from an asynchronous method call.
        /// </summary>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="action">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> OnFailure(this Task<Result> resultTask, Action action)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.OnFailure(action);
        }

        /// <summary>
        /// Returns a failed <see cref="Result"/> from an asynchronous method call.
        /// </summary>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> OnFailure(this Result result, Func<Task> func)
        {
            if (!result.IsSuccess)
                await func().ConfigureAwait(false);

            return result;
        }

        /// <summary>
        /// Returns a failed <see cref="Result{T}"/> from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnFailure<TSource>(
            this Task<Result<TSource>> resultTask, Func<Task> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                await func().ConfigureAwait(false);

            return result;
        }

        /// <summary>
        /// Returns a failed <see cref="Result{T}"/> from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnFailure<TSource>(
            this Task<Result<TSource>> resultTask, Func<Exception, Task> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                await func(result.Error).ConfigureAwait(false);

            return result;
        }

        /// <summary>
        /// Returns a failed <see cref="Result{T}"/> from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="action">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnFailure<TSource>(
            this Task<Result<TSource>> resultTask, Action action)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);
            return result.OnFailure(action);
        }

        /// <summary>
        /// Returns a failed <see cref="Result{T}"/> from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="action">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnFailure<TSource>(
            this Task<Result<TSource>> resultTask, Action<Exception> action)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);
            return result.OnFailure(action);
        }

        /// <summary>
        /// Returns a failed <see cref="Result{T}"/> from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnFailure<TSource>(this Result<TSource> result, Func<Task> func)
        {
            if (!result.IsSuccess)
                await func().ConfigureAwait(false);

            return result;
        }

        /// <summary>
        /// Returns a failed <see cref="Result{T}"/> from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnFailure<TSource>(
            this Result<TSource> result, Func<Exception, Task> func)
        {
            if (!result.IsSuccess)
                await func(result.Error).ConfigureAwait(false);

            return result;
        }

        #endregion
    }
}
