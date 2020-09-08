import { trigger, state, style, transition, animate } from '@angular/animations';


export const animationRightToggle =
    trigger('animationRightToggle', [
        state('in', style({
            transform: 'translate3d(0,0,0)',
            opacity: '1',
            visibility: 'visiable'
        })),
        state('out', style({
            transform: 'translate3d(100%, 0, 0)',
            opacity: '0',
            visibility: 'hidden'
        })),
        transition('in => out', animate('400ms ease-in-out')),
        transition('out => in', animate('400ms ease-in-out'))
    ]);