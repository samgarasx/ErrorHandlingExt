using System;

namespace ErrorHandlingExt.Extensions
{
    public static class ResultExtension
    {
        #region Success Result Extension
        public static Result<TResult> OnSuccess<TResult>(this Result result, Func<TResult> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return Result<TResult>.FromSuccess(func());
        }

        public static Result<TResult> OnSuccess<TResult>(this Result result, Func<Result<TResult>> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return func();
        }

        public static Result OnSuccess<TSource>(this Result<TSource> result, Func<TSource, Result> func)
        {
            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            return func(result.Value);
        }

        public static Result OnSuccess(this Result result, Func<Result> func)
        {
            if (!result.IsSuccess)
                return result;

            return func();
        }

        public static Result OnSuccess(this Result result, Action action)
        {
            if (result.IsSuccess)
                action();

            return result;
        }

        public static Result<TResult> OnSuccess<TSource, TResult>(
            this Result<TSource> result, Func<TSource, TResult> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = func(result.Value);

            return Result<TResult>.FromSuccess(value);
        }

        public static Result<TResult> OnSuccess<TSource, TResult>(
            this Result<TSource> result, Func<TSource, Result<TResult>> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return func(result.Value);
        }

        public static Result<TResult> OnSuccess<TSource, TResult>(
            this Result<TSource> result, Func<Result<TResult>> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return func();
        }

        public static Result<TSource> OnSuccess<TSource>(this Result<TSource> result, Action<TSource> action)
        {
            if (result.IsSuccess)
                action(result.Value);

            return result;
        }
        #endregion

        #region Ensure Result Extension
        public static Result Ensure(this Result result, Func<bool> predicate, Exception error)
        {
            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            if (!predicate())
                return Result.FromFailure(error);

            return Result.FromSuccess();
        }

        public static Result<TSource> Ensure<TSource>(
            this Result<TSource> result, Func<TSource, bool> predicate, Exception error)
        {
            if (!result.IsSuccess)
                return Result<TSource>.FromFailure(result.Error);

            if (!predicate(result.Value))
                return Result<TSource>.FromFailure(error);

            return Result<TSource>.FromSuccess(result.Value);
        }
        #endregion

        #region Map Result Extension
        public static Result<TResult> Map<TResult>(this Result result, Func<TResult> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return Result<TResult>.FromSuccess(func());
        }

        public static Result<TResult> Map<TSource, TResult>(this Result<TSource> result, Func<TSource, TResult> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = func(result.Value);

            return Result<TResult>.FromSuccess(value);
        }
        #endregion

        #region Both Result Extension
        public static TResult OnBoth<TResult>(this Result result, Func<Result, TResult> func)
        {
            return func(result);
        }

        public static TResult OnBoth<TSource, TResult>(this Result<TSource> result, Func<Result<TSource>, TResult> func)
        {
            return func(result);
        }
        #endregion

        #region Failure Result Extension
        public static Result OnFailure(this Result result, Action action)
        {
            if (!result.IsSuccess)
                action();

            return result;
        }

        public static Result OnFailure(this Result result, Action<Exception> action)
        {
            if (!result.IsSuccess)
                action(result.Error);

            return result;
        }

        public static Result<TSource> OnFailure<TSource>(this Result<TSource> result, Action action)
        {
            if (!result.IsSuccess)
                action();

            return result;
        }

        public static Result<TSource> OnFailure<TSource>(this Result<TSource> result, Action<Exception> action)
        {
            if (!result.IsSuccess)
                action(result.Error);

            return result;
        }
        #endregion
    }
}
