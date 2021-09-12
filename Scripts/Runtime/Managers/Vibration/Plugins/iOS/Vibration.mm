#import <Foundation/Foundation.h>
#import <AudioToolbox/AudioToolbox.h>
#import <UIKit/UIKit.h>

#import "Vibration.h"

#define USING_IPAD UI_USER_INTERFACE_IDIOM() == UIUserInterfaceIdiomPad

@interface Vibration ()

@end

@implementation Vibration


#pragma mark - Vibrate

+ (BOOL) hasVibrator {
    return !(USING_IPAD);
}
+ (void) vibrate:(long)defaultVibrationTime {
    AudioServicesPlaySystemSound(kSystemSoundID_Vibrate);
}
+ (void) vibrateWarning:(long)defaultVibrationTime :(long)warningVibrationDelay {
    for (int i = 0; i < 3; i++)
    {
        AudioServicesPlaySystemSound(kSystemSoundID_Vibrate);
        sleep(warningVibrationDelay);
    }
}

@end
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#pragma mark - "C"

extern "C" {
    bool _HasVibrator () {
        return [Vibration hasVibrator];
    }
    void _Vibrate (long defaultVibrationTime) {
        [Vibration vibrate:defaultVibrationTime];
    }
    void _VibrateWarning (long defaultVibrationTime, long warningVibrationDelay) {
        [Vibration vibrateWarning:defaultVibrationTime :warningVibrationDelay];
    }
}
