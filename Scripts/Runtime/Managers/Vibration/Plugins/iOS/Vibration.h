#import <Foundation/Foundation.h>

@interface Vibration : NSObject

#pragma mark - Vibrate

+ (BOOL) hasVibrator;

+ (void) vibrateDefault;
+ (void) vibratePeek;
+ (void) vibratePop;
+ (void) vibrateWarning;

@end
