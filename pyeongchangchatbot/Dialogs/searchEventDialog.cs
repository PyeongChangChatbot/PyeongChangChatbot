namespace pyeongchangchatbot.Dialogs
{
    using Microsoft.Bot.Builder.Dialogs;
    using System;
    using System.Threading.Tasks;
    using Microsoft.Bot.Connector;

    [Serializable]
    public class searchEventDialog : IDialog<string>
    {
        private const string event1 = "개회식";
        private const string event2 = "알파인 스키";
        private const string event3 = "바이애슬론";
        private const string event4 = "봅슬레이";
        private const string event5 = "크로스컨트리 스키";
        private const string event6 = "컬링";
        private const string event7 = "피겨 스케이팅";
        private const string event8 = "프리스타일스키";
        private const string event9 = "아이스 하키";
        private const string event10 = "루지";
        private const string event11 = "노르딕 복합";
        private const string event12 = "쇼트트랙스피드 스케이팅";
        private const string event13 = "스켈레톤";
        private const string event14 = "스키점프";
        private const string event15 = "스노보드";
        private const string event16 = "스피드 스케이팅";
        private const string event17 = "폐회식";

       

        public async Task StartAsync(IDialogContext context)
        {
            PromptDialog.Choice(
                context,
                this.AfterChoiceSelected,
                new[] { event1, event2, event3, event4, event5, event6, event7, event8, event9, event10,
                    event11, event12, event13, event14, event15, event16, event17},
                "원하시는 경기를 선택해주세요",
                "원하시는 경기를 선택해주세요",
                attempts: 3);
        }
        
        private async Task AfterChoiceSelected(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                string selection = await result;

                await context.PostAsync(selection + " 경기를 선택하였습니다. 잠시만 기다려주세요.");

                switch (selection)
                {
                    case event1:
                        // 데이터베이스 집어넣기

                        break;
                    case event2:
                        // 데이터베이스 집어넣기

                        break;
                    case event3:
                        // 데이터베이스 집어넣기

                        break;
                    case event4:
                        // 데이터베이스 집어넣기

                        break;
                    case event5:
                        // 데이터베이스 집어넣기

                        break;
                    case event6:
                        // 데이터베이스 집어넣기

                        break;
                    case event7:
                        // 데이터베이스 집어넣기

                        break;
                    case event8:
                        // 데이터베이스 집어넣기

                        break;
                    case event9:
                        // 데이터베이스 집어넣기

                        break;
                    case event10:
                        // 데이터베이스 집어넣기

                        break;
                    case event11:
                        // 데이터베이스 집어넣기

                        break;
                    case event12:
                        // 데이터베이스 집어넣기

                        break;
                    case event13:
                        // 데이터베이스 집어넣기

                        break;
                    case event14:
                        // 데이터베이스 집어넣기

                        break;
                    case event15:
                        // 데이터베이스 집어넣기

                        break;
                    case event16:
                        // 데이터베이스 집어넣기

                        break;
                    case event17:
                        // 데이터베이스 집어넣기

                        break;
                }

                context.Done(selection);
                
            }
            catch (TooManyAttemptsException)
            {
                await this.StartAsync(context);
            }
        }
    }
}