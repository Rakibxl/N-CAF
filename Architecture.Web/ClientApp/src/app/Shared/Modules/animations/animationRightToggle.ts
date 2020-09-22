import { trigger, state, style, transition, animate } from '@angular/animations';


export const animationRightToggle =
    trigger('animationRightToggle', [
        state('in', style({
            transform: 'perspective(0) rotateY(0) translateX(0)',
            opacity: '1',
            visibility: 'visiable'
        })),
        state('out', style({
            transform: 'perspective(1278px) rotateY(56deg) translateX(300px)',
            overflow: 'hidden',
            opacity: '0',
            visibility: 'hidden'
        })),
        transition('in => out', animate('550ms ease-in-out')),
        transition('out => in', animate('550ms ease-in-out'))
    ]);

export const scaleAnimation =
    trigger('scaleAnimation', [
        state('in', style({
            opacity: '1',
            visibility: 'visiable'
        })),
        state('out', style({
            height: '0',
            width: '0',
            transform: 'translate(0)',
            opacity: '0',
            overflow: 'hidden',
            visibility: 'hidden'
        })),
        transition('in => out', animate('550ms ease-in-out')),
        transition('out => in', animate('550ms ease-in-out'))
    ]);