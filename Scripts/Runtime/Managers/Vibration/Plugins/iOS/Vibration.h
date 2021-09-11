#import <Foundation/Foundation.h>

@interface Vibration : NSObject

#pragma mark - Vibrate

+ (BOOL) hasVibrator;
+ (void) vibrate:(long)defaultVibrationTime;
+ (void) vibrateWarning:(long)defaultVibrationTime, (long)warningVibrationDelay;

@end
