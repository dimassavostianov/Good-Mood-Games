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

+ (void) vibrateDefault: {
    AudioServicesPlaySystemSound(kSystemSoundID_Vibrate);
}
+ (void) vibratePeek: {
    AudioServicesPlaySystemSound(1519);
}
+ (void) vibratePop: {
    AudioServicesPlaySystemSound(1520);
}
+ (void) vibrateWarning: {
    AudioServicesPlaySystemSound(1521);
}

@end
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#pragma mark - "C"

extern "C" {
    bool _HasVibrator () {
        return [Vibration hasVibrator];
    }

    void _VibrateDefault () {
        [Vibration vibrateDefault];
    }
    void _VibratePeek () {
        [Vibration vibratePeek];
    }
    void _VibratePop () {
        [Vibration vibratePop];
    }
    void _VibrateWarning () {
        [Vibration vibrateWarning];
    }
}
