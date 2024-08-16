import { UserState } from './user/user.reducer';
import { SubscriptionState } from './subscription/subscription.reducer';

export interface AppState {
  users: UserState;
  subscriptions: SubscriptionState;
}