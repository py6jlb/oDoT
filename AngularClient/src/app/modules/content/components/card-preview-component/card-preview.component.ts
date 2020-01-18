import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CardModel } from '../../models/card.model';
import { faEllipsisH, faBed, faTrash, faCheck, faCrown } from '@fortawesome/free-solid-svg-icons'
import { faFacebookSquare, faTwitterSquare, faYoutubeSquare, faInstagram, faVk } from '@fortawesome/free-brands-svg-icons'
import { ContentDataService } from '../../services/content-data.service';


@Component({
    selector: 'app-card-preview',
    templateUrl: './card-preview.component.html',
    styleUrls: ['./card-preview.component.scss']
})

export class CardPreviewComponent implements OnInit {
    faEllipsisH = faEllipsisH;
    faBed = faBed;
    fafasebookSquare = faFacebookSquare;
    faTwitterSquare = faTwitterSquare;
    faYoutubeSquare = faYoutubeSquare;
    faInstagram = faInstagram;
    faVk = faVk;
    faTrash = faTrash;
    faCheck = faCheck;
    faCrown = faCrown;

    @Input() cardData: CardModel;
    @Output() taskDeleted: EventEmitter<void> = new EventEmitter();
    @Output() taskClosed: EventEmitter<void> = new EventEmitter();
    
    constructor(private dataService: ContentDataService) { }

    ngOnInit() {
        
    }
}