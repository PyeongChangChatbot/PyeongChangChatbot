namespace pyeongchangchatbot.Dialogs
{
    using Microsoft.Bot.Builder.Dialogs;
    using System;
    using System.Threading.Tasks;
    using Microsoft.Bot.Connector;
    
    [Serializable]
    public class searchDateDialog : IDialog<string>
    {
        private int attempts = 5;

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("원하는 날짜를 입력하세요. 8일부터 25일까지 입력할 수 있습니다.\n다음 형식에 맞춰 입력하세요. e.g. 08 or 25");
            
            context.Wait(this.MessageReceivedAsync);
        }


        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            string dates = message.Text.Trim();

            /* If the message returned is a valid name, return it to the calling dialog. */
            if ((message.Text != null) && (dates.Length == 2) && (dates[0]>=48 && dates[0]<=57) && (dates[1] >= 48 && dates[1] <= 57))
            {
                int exactDate = int.Parse(dates);

                if(exactDate >= 8 && exactDate <= 25)
                {
                    await context.PostAsync(exactDate + "일을 선택하였습니다. 잠시만 기다려주세요.");

                    
                    
                    
                    //  데이터베이스에서 정보 끌어다놓기.




                    /* Completes the dialog, removes it from the dialog stack, and returns the result to the parent/calling
                    dialog. */
                    context.Done(dates);
                }
                else
                {
                    --attempts;
                    if (attempts > 0)
                    {
                        await context.PostAsync("선택 가능한 날짜는 8일부터 25일까지입니다. 형식에 맞게 원하시는 날짜를 다시 입력해주세요. e.g. 08 or 25");

                        context.Wait(this.MessageReceivedAsync);
                    }
                    else
                    {
                        /* Fails the current dialog, removes it from the dialog stack, and returns the exception to the 
                            parent/calling dialog. */
                        context.Fail(new TooManyAttemptsException("너무 많이 잘못된 메시지를 입력하였습니다."));
                    }
                }

            }
            /* Else, try again by re-prompting the user. */
            else
            {
                --attempts;
                if (attempts > 0)
                {
                    await context.PostAsync("이해하지 못하였습니다. 형식에 맞게 원하시는 날짜를 다시 입력해주세요. e.g. 08 or 25");

                    context.Wait(this.MessageReceivedAsync);
                }
                else
                {
                    /* Fails the current dialog, removes it from the dialog stack, and returns the exception to the 
                        parent/calling dialog. */
                    context.Fail(new TooManyAttemptsException("너무 많이 잘못된 메시지를 입력하였습니다."));
                }
            }
            


        }
    }

}