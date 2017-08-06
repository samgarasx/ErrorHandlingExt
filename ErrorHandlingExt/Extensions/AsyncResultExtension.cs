using System;
using System.Threading.Tasks;

namespace ErrorHandlingExt.Extensions
{
    public static class AsyncResultExtension
    {
        #region Success Async Result Extension
        public static async Task<Result<TResult>> OnSuccess<TResult>(
            this Task<Result> resultTask, Func<Task<TResult>> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = await func().ConfigureAwait(false);

            return Result<TResult>.FromSuccess(value);
        }

        public static async Task<Result<TResult>> OnSuccess<TResult>(
            this Task<Result> resultTask, Func<Task<Result<TResult>>> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return await func().ConfigureAwait(false);
        }

        public static async Task<Result> OnSuccess<TSource>(
            this Task<Result<TSource>> resultTask, Func<TSource, Task<Result>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            return await func(result.Value).ConfigureAwait(false);
        }

        public static async Task<Result> OnSuccess(this Task<Result> resultTask, Func<Task<Result>> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return result;

            return await func().ConfigureAwait(false);
        }

        public static async Task<Result<TResult>> OnSuccess<TResult>(this Task<Result> resultTask, Func<TResult> func)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        public static async Task<Result<TResult>> OnSuccess<TResult>(
            this Task<Result> resultTask, Func<Result<TResult>> func)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        public static async Task<Result> OnSuccess<TSource>(
            this Task<Result<TSource>> resultTask, Func<TSource, Result> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        public static async Task<Result> OnSuccess(this Task<Result> resultTask, Func<Result> func)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        public static async Task<Result<TResult>> OnSuccess<TResult>(this Result result, Func<Task<TResult>> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = await func().ConfigureAwait(false);

            return Result<TResult>.FromSuccess(value);
        }

        public static async Task<Result<TSource>> OnSuccess<TSource>(
            this Result result, Func<Task<Result<TSource>>> func)
        {
            if (!result.IsSuccess)
                return Result<TSource>.FromFailure(result.Error);

            return await func().ConfigureAwait(false);
        }

        public static async Task<Result> OnSuccess<TSource>(
            this Result<TSource> result, Func<TSource, Task<Result>> func)
        {
            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            return await func(result.Value).ConfigureAwait(false);
        }

        public static async Task<Result> OnSuccess(this Result result, Func<Task<Result>> func)
        {
            if (!result.IsSuccess)
                return result;

            return await func().ConfigureAwait(false);
        }

        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TSource, Task<TResult>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = await func(result.Value);

            return Result<TResult>.FromSuccess(value);
        }

        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TSource, Task<Result<TResult>>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return await func(result.Value);
        }

        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<Task<Result<TResult>>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return await func().ConfigureAwait(false);
        }

        public static async Task<Result<TSource>> OnSuccess<TSource>(
            this Task<Result<TSource>> resultTask, Func<TSource, Task> action)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (result.IsSuccess)
                await action(result.Value).ConfigureAwait(false);

            return result;
        }

        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TSource, TResult> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TSource, Result<TResult>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<Result<TResult>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        public static async Task<Result<TSource>> OnSuccess<TSource>(
            this Task<Result<TSource>> resultTask, Action<TSource> action)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(action);
        }

        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Result<TSource> result, Func<TSource, Task<TResult>> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = await func(result.Value).ConfigureAwait(false);

            return Result<TResult>.FromSuccess(value);
        }

        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Result<TSource> result, Func<TSource, Task<Result<TResult>>> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return await func(result.Value).ConfigureAwait(false);
        }

        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Result<TSource> result, Func<Task<Result<TResult>>> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return await func().ConfigureAwait(false);
        }

        public static async Task<Result<TSource>> OnSuccess<TSource>(
            this Result<TSource> result, Func<TSource, Task> action)
        {
            if (result.IsSuccess)
                await action(result.Value).ConfigureAwait(false);

            return result;
        }
        #endregion

        #region Ensure Async Result Extension
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

        public static async Task<Result> Ensure(
            this Task<Result> resultTask, Func<bool> predicate, Exception error)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.Ensure(predicate, error);
        }

        public static async Task<Result> Ensure(this Result result, Func<Task<bool>> predicate, Exception error)
        {
            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            if (!await predicate().ConfigureAwait(false))

                return Result.FromFailure(error);

            return Result.FromSuccess();
        }

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

        public static async Task<Result<TSource>> Ensure<TSource>(
            this Task<Result<TSource>> resultTask, Func<TSource, bool> predicate, Exception error)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);
            return result.Ensure(predicate, error);
        }

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
        public static async Task<Result<TResult>> Map<TResult>(this Task<Result> resultTask, Func<Task<TResult>> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = await func().ConfigureAwait(false);

            return Result<TResult>.FromSuccess(value);
        }

        public static async Task<Result<TResult>> Map<TResult>(this Task<Result> resultTask, Func<TResult> func)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.Map(func);
        }

        public static async Task<Result<TResult>> Map<TResult>(this Result result, Func<Task<TResult>> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = await func().ConfigureAwait(false);

            return Result<TResult>.FromSuccess(value);
        }

        public static async Task<Result<TResult>> Map<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TSource, Task<TResult>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = await func(result.Value).ConfigureAwait(false);

            return Result<TResult>.FromSuccess(value);
        }

        public static async Task<Result<TResult>> Map<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TSource, TResult> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);
            return result.Map(func);
        }

        public static async Task<Result<TResult>> Map<TSource, TResult>(
            this Result<TSource> result, Func<TSource, Task<TResult>> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = await func(result.Value).ConfigureAwait(false);

            return Result<TResult>.FromSuccess(value);
        }
        #endregion

        #region Both Async Result Extension
        public static async Task<TResult> OnBoth<TResult>(this Task<Result> resultTask, Func<Result, Task<TResult>> func)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return await func(result).ConfigureAwait(false);
        }

        public static async Task<TResult> OnBoth<TResult>(this Task<Result> resultTask, Func<Result, TResult> func)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.OnBoth(func);
        }

        public static async Task<Tresult> OnBoth<Tresult>(this Result result, Func<Result, Task<Tresult>> func)
        {
            return await func(result).ConfigureAwait(false);
        }

        public static async Task<TResult> OnBoth<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<Result<TSource>, Task<TResult>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);
            return await func(result).ConfigureAwait(false);
        }

        public static async Task<TResult> OnBoth<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<Result<TSource>, TResult> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);
            return result.OnBoth(func);
        }

        public static async Task<TResult> OnBoth<TSource, TResult>(
            this Result<TSource> result, Func<Result<TSource>, Task<TResult>> func)
        {
            return await func(result).ConfigureAwait(false);
        }
        #endregion

        #region Failure Async Result Extension
        public static async Task<Result> OnFailure(this Task<Result> resultTask, Func<Task> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                await func().ConfigureAwait(false);

            return result;
        }

        public static async Task<Result> OnFailure(this Task<Result> resultTask, Action action)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.OnFailure(action);
        }

        public static async Task<Result> OnFailure(this Result result, Func<Task> func)
        {
            if (!result.IsSuccess)
                await func().ConfigureAwait(false);

            return result;
        }

        public static async Task<Result<TSource>> OnFailure<TSource>(
            this Task<Result<TSource>> resultTask, Func<Task> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                await func().ConfigureAwait(false);

            return result;
        }

        public static async Task<Result<TSource>> OnFailure<TSource>(
            this Task<Result<TSource>> resultTask, Func<Exception, Task> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                await func(result.Error).ConfigureAwait(false);

            return result;
        }

        public static async Task<Result<TSource>> OnFailure<TSource>(
            this Task<Result<TSource>> resultTask, Action action)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);
            return result.OnFailure(action);
        }

        public static async Task<Result<TSource>> OnFailure<TSource>(
            this Task<Result<TSource>> resultTask, Action<Exception> action)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);
            return result.OnFailure(action);
        }

        public static async Task<Result<TSource>> OnFailure<TSource>(
            this Result<TSource> result, Func<Task> func)
        {
            if (!result.IsSuccess)
                await func().ConfigureAwait(false);

            return result;
        }

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
